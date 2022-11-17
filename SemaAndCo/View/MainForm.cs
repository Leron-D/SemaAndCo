using Ionic.Zip;
using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SemaAndCo.View
{
    public partial class MainForm : TemplateForm
    {
        string saveText;
        string extension;
        public MainForm()
        {
            IntroForm form = new IntroForm();
            form.ShowDialog();
            InitializeComponent();
            AppendToArchive();
        }

        private void AppendToArchive()
        {
            try
            {
                listView.SmallImageList = imageList;

                bool isZipExist = false;
                using (var zipFile = ZipFile.Read(Path.Combine(Properties.Settings.Default.savingPath, "SemaAndCo.zip")))
                {
                    isZipExist = zipFile.ContainsEntry($"{CurrentUser.User.Login}.zip");
                }
                if (!isZipExist)
                {
                    string tempPath = Path.Combine(Path.GetTempPath(), $"{CurrentUser.User.Login}.zip");
                    DotNetZipHelper.AppendZipToArchive($"{Path.Combine(Properties.Settings.Default.savingPath, "SemaAndCo.zip")}",
                                            new List<string> { DotNetZipHelper.CreateArchive(tempPath) },
                                            CurrentUser.User.Password);
                    File.Delete(tempPath);
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int GetIndex(string filename)
        {
            switch (Path.GetExtension(filename))
            {
                case ".docx":
                case ".doc":
                    return 0;
                case ".png":
                case ".jpg":
                case ".bmp":
                case ".jpeg":
                case ".tiff":
                case ".gif":
                    return 1;
                case ".exe":
                case ".msi":
                    return 2;
                case ".txt":
                    return 3;
                case ".xls":
                case ".xlsx":
                    return 4;
                case ".zip":
                case ".rar":
                case ".7z":
                    return 5;
                default:
                    return 6;
            }
        }

        void LoadData()
        {
            listView.Items.Clear();
            using (var zip = DotNetZipHelper.ReadSubZipWithPassword($@"{Properties.Settings.Default.savingPath}\SemaAndCo.zip", $"{CurrentUser.User.Login}.zip",
                                                                    CurrentUser.User.Password))
            {
                foreach (ZipEntry e in zip.Entries)
                {
                    ListViewItem item = new ListViewItem(Path.GetFileName(e.FileName));
                    item.Tag = e;
                    int index = GetIndex(e.FileName);
                    item.ImageIndex = index;
                    listView.Items.Add(item);
                }
            }
        }

        private async void uploadButton_Click(object sender, EventArgs e)
        {
            pictureBox.Visible = true;
            await UploadDataAsync();
            pictureBox.Visible = false;
        }

        public async Task UploadDataAsync()
        {
            List<string> filesToAppend = new List<string>();
            try
            {
                using (var zip = DotNetZipHelper.ReadSubZipWithPassword(Path.Combine(Properties.Settings.Default.savingPath, "SemaAndCo.zip"), $"{CurrentUser.User.Login}.zip", CurrentUser.User.Password))
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog()
                    {
                        Multiselect = true,
                        Title = "Выберите файлы"
                    };
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            try
                            {
                                filesToAppend.Add(file);
                            }
                            catch (ArgumentException ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        await Task.Run(() => DotNetZipHelper.AppendFilesToZip(Path.Combine(Properties.Settings.Default.savingPath, "SemaAndCo.zip"),
                                                                              $"{CurrentUser.User.Login}.zip", filesToAppend, CurrentUser.User.Password));
                    }
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            List<string> filesToDelete = new List<string>();
            try
            {
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    filesToDelete.Add(item.Text);
                }
                DotNetZipHelper.DeleteFilesFromZip(Path.Combine(Properties.Settings.Default.savingPath, "SemaAndCo.zip"),
                                                    $"{CurrentUser.User.Login}.zip", filesToDelete, CurrentUser.User.Password);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count == 1)
                {
                    DotNetZipHelper.GetInfoFiles(Path.Combine(Properties.Settings.Default.savingPath, "SemaAndCo.zip"), $"{CurrentUser.User.Login}.zip", listView.SelectedItems[0].Text, CurrentUser.User.Password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthorizationForm form = new AuthorizationForm();
            form.ShowDialog();
            this.Close();
        }

        private void administrationButton_Click(object sender, EventArgs e)
        {
            AdministrationForm form = new AdministrationForm();
            form.FormClosed += Form_FormClosed;
            form.Show();
            administrationButton.Enabled = false;
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            administrationButton.Enabled = true;
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            saveText = listView.SelectedItems[0].Text;
            extension = saveText.Split('.').Last();
            listView.SelectedItems[0].Text = "";
            var position = listView.SelectedItems[0].Position;
            int x = position.X + 63;
            int y = position.Y + 90;
            renameTextBox.Visible = true;
            renameTextBox.Width = saveText.Length * 9 + 30;
            renameTextBox.Text = saveText.Remove(saveText.Length - extension.Length - 1);
            renameTextBox.Location = new Point(x, y);
            renameTextBox.Focus();
            renameButton.Enabled = deleteButton.Enabled = infoButton.Enabled = listView.Enabled = false;
        }

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                renameButton.Enabled = deleteButton.Enabled = infoButton.Enabled = true;
            }
            else if (listView.SelectedItems.Count == 0)
            {
                renameButton.Enabled = deleteButton.Enabled = infoButton.Enabled = false;
            }
            else
            {
                renameButton.Enabled = infoButton.Enabled = false;
            }
        }

        private void renameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            renameTextBox.Width = renameTextBox.Text.Length * 9 + 30;
            RenameMethod(e);
        }

        private void RenameMethod(KeyEventArgs e)
        {
            try
            {
                using (ZipFile zip = DotNetZipHelper.ReadSubZipWithPassword(Path.Combine(Properties.Settings.Default.savingPath, "SemaAndCo.zip"),
                                            $"{CurrentUser.User.Login}.zip", CurrentUser.User.Password))
                {
                    var zipEntry = zip.Entries.FirstOrDefault(z => z.FileName == $"{renameTextBox.Text}.{extension}");
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (!String.IsNullOrEmpty(renameTextBox.Text) && renameTextBox.Text != saveText.Remove(saveText.Length - extension.Length - 1))
                        {
                            if (zip.Contains(zipEntry))
                            {
                                MessageBox.Show("Название файла уже занято", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                DotNetZipHelper.RenameZipEntries(Path.Combine(Properties.Settings.Default.savingPath, "SemaAndCo.zip"),
                                    $"{CurrentUser.User.Login}.zip", CurrentUser.User.Password, saveText, $"{renameTextBox.Text}.{extension}");
                            }
                        }
                        LoadData();
                        listView.Enabled = true;
                        renameButton.Enabled = renameTextBox.Visible = deleteButton.Enabled = infoButton.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
