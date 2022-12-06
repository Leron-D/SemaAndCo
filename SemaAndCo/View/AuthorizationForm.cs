using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Common;
using SemaAndCo.Model;
using SemaAndCo.Presenter;
using SemaAndCo.Supporting;
using SemaAndCo.View;

namespace SemaAndCo
{
    public partial class AuthorizationForm : Form, ILoginView
    {
        LoginPresenter presenter;
        bool result;

        public AuthorizationForm()
        {
            IntroForm introForm = new IntroForm(533);
            introForm.ShowDialog();
            InitializeComponent();
            presenter = new LoginPresenter(this);
            LoadForm();

            if (Properties.Settings.Default.authLogin != "" && Properties.Settings.Default.password != "")
            {
                loginTextBox.Text = Properties.Settings.Default.authLogin;
                passwordTextBox.Text = Properties.Settings.Default.password;
                rememberCheckBox.Checked = true;
            }
        }

        private void LoadForm()
        {
            ToolTip tool = new ToolTip();
            tool.SetToolTip(savingPathButton, "Выбор папки для сохранения");
            tool.SetToolTip(administrationButton, "Администрирование");
            CurrentUser.FtpUser = null;
        }

        public string Login
        {
            set
            {
                loginTextBox.Text = value;
            }
            get
            {
                return loginTextBox.Text;
            }
        }
        public string Password
        {
            set
            {
                passwordTextBox.Text = value;
            }
            get
            {
                return passwordTextBox.Text;
            }
        }
        public bool SaveOptions
        {
            set
            {
                rememberCheckBox.Checked = value;
            }
            get
            {
                return rememberCheckBox.Checked;
            }
        }

        private void ToRegistrationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
            this.Close();
        }

        private void ForgotPasswordLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecoveryForm recoveryForm = new RecoveryForm();
            recoveryForm.ShowDialog();
            this.Close();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            await LoginMethodAsync();
            if (result)
            {
                Hide();
                MainForm form = new MainForm();
                form.ShowDialog();
                Close();
            }
        }

        private async Task LoginMethodAsync()
        {
            try
            {
                administrationButton.Visible = false;
                introPictureBox.Dock = DockStyle.Fill;
                introPictureBox.Enabled = true;
                introPictureBox.Visible = true;
                await Task.Run(() =>
                {
                    if (presenter.LoginMethod(Login, Password))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                });
                administrationButton.Visible = true;
                introPictureBox.Dock = DockStyle.None;
                introPictureBox.Visible = false;
                introPictureBox.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await LoginMethodAsync();
                if (result)
                {
                    Hide();
                    MainForm form = new MainForm();
                    form.ShowDialog();
                    Close();
                }
            }
        }

        private void SavingPathButton_Click(object sender, EventArgs e)
        {
            Hide();
            SelectFolderForm form = new SelectFolderForm();
            form.ShowDialog();
            Close();
        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            AutomaticEnter();
        }

        private void AutomaticEnter()
        {
            if (!File.Exists(Path.Combine(Properties.Settings.Default.savingPath, "autonom.zip")))
            {
                DotNetZipHelper.CreateArchive("autonom.zip", "autonom".EncryptString());
            }
            LocalUser.Automatic = true;
            Hide();
            MainForm form = new MainForm();
            form.ShowDialog();
            Close();
        }

        private void AdministrationButton_Click(object sender, EventArgs e)
        {
            introPictureBox.Dock = DockStyle.Fill;
            introPictureBox.Visible = true;
            GoToAdministration();
            introPictureBox.Dock = DockStyle.None;
            introPictureBox.Visible = false;
        }

        private void GoToAdministration()
        {
            try
            {
                Core.goAdministration = true;
                AccessRecoveryForm form = new AccessRecoveryForm();
                Hide();
                form.ShowDialog();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
