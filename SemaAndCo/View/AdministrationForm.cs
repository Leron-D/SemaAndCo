using MySql.Data.MySqlClient;
using SemaAndCo.Model;
using SemaAndCo.Presenter;
using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.View
{
    public partial class AdministrationForm : TemplateForm, IAdministrationView
    {
        int pageSize = 1;
        int currentPage = 1;
        AdministrationPresenter presenter;
        SendMail sendMail = new SendMail();
        ReferenceForm referenceForm = new ReferenceForm();
        string ftpUrl = @"ftp://91.122.211.144:50021/";

        public AdministrationForm()
        {
            InitializeComponent();
            usersGridView.AutoGenerateColumns = false;
            presenter = new AdministrationPresenter(this);
            try
            {
                pageSize = presenter.AutoSize(pageSize, usersGridView.Size.Height);
                presenter.UsersLoad();
                presenter.Navigation(pageSize, currentPage);
                Properties.Settings.Default.adminIntro = true;
                introPictureBox.Width = 236;
                introPictureBox.Height = 255;
                introPictureBox.Left = (ClientSize.Width - introPictureBox.Width) / 2;
                introPictureBox.Top = (ClientSize.Height - introPictureBox.Height) / 2;
                ToolTip tool = new ToolTip();
                tool.SetToolTip(referenceButton, "О программе");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Pages
        public decimal CurrentPage
        {
            set
            {
                try
                {
                    currentPageNumeric.Value = value;
                }
                catch (ArgumentOutOfRangeException) { }
            }
            get
            {
                return currentPageNumeric.Value;
            }
        }
        public decimal CurrentPageMax
        {
            set
            {
                currentPageNumeric.Maximum = value;
            }
            get
            {
                return currentPageNumeric.Maximum;
            }
        }
        public decimal CurrentPageMin
        {
            set
            {
                currentPageNumeric.Minimum = value;
            }
            get
            {
                return currentPageNumeric.Minimum;
            }
        }
        public string TotalPages
        {
            set
            {
                totalPagesLabel.Text = value;
            }
            get
            {
                return totalPagesLabel.Text;
            }
        }
        public string ResultsAmount
        {
            set
            {
                resultsAmountLabel.Text = value;
            }
        }
        public bool FirstPage
        {
            set
            {
                firstPageButton.Enabled = value;
            }
        }
        public bool LeftPage
        {
            set
            {
                leftPageButton.Enabled = value;
            }
        }
        public bool RightPage
        {
            set
            {
                rightPageButton.Enabled = value;
            }
        }
        public bool LastPage
        {
            set
            {
                lastPageButton.Enabled = value;
            }
        }
        #endregion

        public void ChangeEnableButtons()
        {
            if(usersGridView.SelectedCells.Count == 0)
            {
                changeButton.Enabled = deleteButton.Enabled = false;
            }
            else
            {
                changeButton.Enabled = deleteButton.Enabled = true;
            }  
        }

        public string SearchTextBox
        {
            set
            {
                searchTextBox.Text = value;
            }
            get 
            {
                return searchTextBox.Text; 
            }
        }
        public object SearchData
        {
            set
            {
                usersGridView.DataSource = value;
            }
            get
            {
                object[][] result = new object[usersGridView.ColumnCount][];
                for (int i = 0; i < usersGridView.ColumnCount; i++)
                {
                    result[i] = new object[usersGridView.RowCount];
                    for (int j = 0; j < usersGridView.RowCount; j++)
                    {
                        result[i][j] = usersGridView[i, j].Value;
                    }
                }
                return result;
            }
        }

        private void FirstPageButton_Click(object sender, EventArgs e)
        {
            currentPageNumeric.Value = 1;
        }

        private void LeftPageButton_Click(object sender, EventArgs e)
        {
            if (currentPageNumeric.Value > currentPageNumeric.Minimum)
                currentPageNumeric.Value--;
        }

        private void RightPageButton_Click(object sender, EventArgs e)
        {
            if (currentPageNumeric.Value < currentPageNumeric.Maximum)
                currentPageNumeric.Value++;
        }

        private void LastPageButton_Click(object sender, EventArgs e)
        {
            currentPageNumeric.Value = currentPageNumeric.Maximum;
        }

        private void CurrentPageNumeric_ValueChanged(object sender, EventArgs e)
        {
            currentPage = (int)currentPageNumeric.Value;
            presenter.Navigation(pageSize, currentPage);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchMethod();
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchMethod();
            }
        }

        private void SearchMethod()
        {
            try
            {
                presenter.SearchFilterUsers(searchTextBox.Text);
                presenter.Navigation(pageSize, 1);
                currentPageNumeric.Value = currentPageNumeric.Minimum = 1;
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdministrationForm_SizeChanged(object sender, EventArgs e)
        {
            pageSize = presenter.AutoSize(pageSize, usersGridView.Size.Height);
            presenter.SearchFilterUsers(searchTextBox.Text);
            presenter.Navigation(pageSize, 1);
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            addButton.Enabled = changeButton.Enabled = deleteButton.Enabled = true;
            presenter.UsersLoad();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Core.addingUserVariability = true;
            RegistrationForm form = new RegistrationForm();
            form.FormClosed += Form_FormClosed;
            form.Show();
            addButton.Enabled = changeButton.Enabled = deleteButton.Enabled = false;
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            await DeleteUserMethod();
        }

        private async Task DeleteUserMethod()
        {
            try
            {               
                string loginOfUser = "";  
                var message = MessageBox.Show($"Удалить выбранного(-ых) пользователя(-ей)?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);                
                if (message == DialogResult.Yes)
                {
                    introPictureBox.Visible = true;
                    await Task.Run(async () =>
                    {
                        Core context = new Core(Core.StrConnection());
                        FtpUser.semaandcouser user = new FtpUser.semaandcouser();
                        for (int i = 0; i < usersGridView.SelectedRows.Count; i++)
                        {
                            Invoke((MethodInvoker)delegate { loginOfUser = usersGridView.SelectedRows[i].Cells[0].Value.ToString(); });
                            string password = usersGridView.SelectedRows[i].Cells[3].Value.ToString();
                            if (File.Exists(Path.Combine(Properties.Settings.Default.savingPath, $"{loginOfUser}.zip")))
                                File.Delete(Path.Combine(Properties.Settings.Default.savingPath, $"{loginOfUser}.zip"));
                            List<string> filesFromServer = FtpHelper.GetFilesList(ftpUrl, loginOfUser, password);
                            if (filesFromServer != null)
                            {
                                foreach (string file in filesFromServer)
                                {
                                    string fileName = $"{ftpUrl}{file}";

                                    if (await Task.Run(() => FtpHelper.DeleteFile(fileName, loginOfUser, password) == FtpStatusCode.ConnectionClosed))
                                    {
                                        throw new Exception("Отсутствует соединение с сервером");
                                    }
                                }
                            }
                            user = context.semaandcouser.Where(u => u.userid == loginOfUser).FirstOrDefault();
                            context.semaandcouser.Remove(user);
                            context.SaveChanges();
                            sendMail.EnterMailWithChangesOfUser(user.email, "Ваш аккаунт был удалён");
                        }
                    });
                    MessageBox.Show($"Пользователь(-и) успешно удалён(-ены)", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    presenter.UsersLoad();
                    introPictureBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    introPictureBox.Visible = false;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    introPictureBox.Visible = false;
                    Close();
                }
            }
        }

        private void UsersGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ChangeEnableButtons();
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            ChangeUserMethod();
        }

        private void ChangeUserMethod()
        {
            try
            {
                ChangeUserForm form = new ChangeUserForm(usersGridView.SelectedRows[0].Cells[0].Value.ToString());
                form.FormClosed += Form_FormClosed;
                form.Show();
                addButton.Enabled = changeButton.Enabled = deleteButton.Enabled = false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReferenceButton_Click(object sender, EventArgs e)
        {
            referenceButton.Enabled = addButton.Enabled = changeButton.Enabled = deleteButton.Enabled = false;
            referenceForm.FormClosed += ReferenceForm_Closed;
            referenceForm.ShowDialog();
        }
        private void ReferenceForm_Closed(object sender, FormClosedEventArgs e)
        {
            referenceButton.Enabled = addButton.Enabled = changeButton.Enabled = deleteButton.Enabled = false;
        }

        private void AdministrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            referenceForm.Close();
        }
    }
}