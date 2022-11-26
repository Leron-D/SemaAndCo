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
            CreateZip();
            LoadData();
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

        void CreateZip()
        {
            if(!File.Exists(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.User.userid}.zip")))
            {
                DotNetZipHelper.CreateArchive($"{CurrentUser.User.userid}.zip");
            }
        }

        void LoadData()
        {
            listView.Items.Clear();
            if (localRadioButton.Checked)
            {
                using (var zip = ZipFile.Read(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.User.userid}.zip")))
                {
                    foreach (ZipEntry e in zip.Entries)
                    {
                        ListViewItem item = new ListViewItem(Path.GetFileName(e.FileName));
                        listView.SmallImageList = imageList;
                        item.Tag = e;
                        int index = GetIndex(e.FileName);
                        item.ImageIndex = index;
                        listView.Items.Add(item);
                    }
                }
            }
            else
            {
                List<string> filesFromServer = FtpHelper.GetFilesList(@"ftp://91.122.211.144:50021/", CurrentUser.User.userid, CurrentUser.User.passwd);
                foreach (var item in filesFromServer)
                {
                    ListViewItem listItem = new ListViewItem(Path.GetFileName(item));
                    listView.SmallImageList = imageList;
                    listItem.Tag = Path.GetFileName(item);
                    int index = GetIndex(item);
                    listItem.ImageIndex = index;
                    listView.Items.Add(listItem);
                }
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {

            pictureBox.Visible = true;
            UploadData();
            pictureBox.Visible = false;
        }

        public void UploadData()
        {
            List<string> filesToAppend = new List<string>();
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Multiselect = true,
                    Title = "Выберите файлы"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (localRadioButton.Checked)
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
                        DotNetZipHelper.AppendFilesToZip(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.User.userid}.zip"), filesToAppend);
                    }
                    else
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            try
                            {
                                if (!FtpHelper.GetFilesList(@"ftp://91.122.211.144:50021/", CurrentUser.User.userid, CurrentUser.User.passwd).Contains(Path.GetFileName(file)))
                                {
                                    FtpHelper.UploadFile(file, $"ftp://91.122.211.144:50021/{Path.GetFileName(file)}", CurrentUser.User.userid, CurrentUser.User.passwd);
                                    MessageBox.Show("Файлы успешно загружены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    var message = MessageBox.Show($"Файл с именем {Path.GetFileName(file)} уже существует. Вы хотите заменить его?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if(message == DialogResult.Yes)
                                    {
                                        FtpHelper.DeleteFile($"ftp://91.122.211.144:50021/{Path.GetFileName(file)}", CurrentUser.User.userid, CurrentUser.User.passwd);
                                        FtpHelper.UploadFile(file, $"ftp://91.122.211.144:50021/{Path.GetFileName(file)}", CurrentUser.User.userid, CurrentUser.User.passwd);
                                        MessageBox.Show("Файл успешно заменён", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteMethod();
        }

        private void DeleteMethod()
        {
            List<string> filesToDelete = new List<string>();
            try
            {
                if (localRadioButton.Checked)
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        filesToDelete.Add(item.Text);
                    }
                    DotNetZipHelper.DeleteFilesFromZip(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.User.userid}.zip"), filesToDelete);
                    MessageBox.Show("Файлы успешно удалены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        FtpHelper.DeleteFile($"ftp://91.122.211.144:50021/{item.Text}", CurrentUser.User.userid, CurrentUser.User.passwd);
                        MessageBox.Show("Файлы успешно удалены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            GetFileInfo();
        }

        private void GetFileInfo()
        {
            try
            {
                if (listView.SelectedItems.Count == 1)
                {
                    DotNetZipHelper.GetInfoFiles(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.User.userid}.zip"), listView.SelectedItems[0].Text, CurrentUser.User.passwd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AuthorizationForm form = new AuthorizationForm();
            form.ShowDialog();
            this.Close();
        }

        private void AdministrationButton_Click(object sender, EventArgs e)
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

        private void RenameButton_Click(object sender, EventArgs e)
        {
            RenameMethod();
        }

        private void RenameMethod()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ChangeEnabledButtons();
        }

        private void ChangeEnabledButtons()
        {
            if (listView.SelectedItems.Count == 1)
            {
                renameButton.Enabled = downloadButton.Enabled = deleteButton.Enabled = infoButton.Enabled = true;
            }
            else if (listView.SelectedItems.Count == 0)
            {
                renameButton.Enabled = downloadButton.Enabled = deleteButton.Enabled = infoButton.Enabled = false;
            }
            else
            {
                renameButton.Enabled = infoButton.Enabled = false;
                downloadButton.Enabled = true;
            }
        }

        private void RenameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            renameTextBox.Width = renameTextBox.Text.Length * 9 + 30;
            RenameMethod(e);
        }

        private void RenameMethod(KeyEventArgs e)
        {
            try
            {
                using (var zip = ZipFile.Read(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.User.userid}.zip")))
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
                                foreach (ZipEntry entry in zip.ToList())
                                {
                                    if (entry.FileName == saveText)
                                        entry.FileName = $"{renameTextBox.Text}.{extension}";
                                    zip.Save();
                                }
                            }
                        }
                        LoadData();
                        listView.Enabled = true;
                        renameButton.Enabled = renameTextBox.Visible = deleteButton.Enabled = infoButton.Enabled = downloadButton.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            DownloadMethod();
        }

        private void DownloadMethod()
        {
            try
            {
                if (localRadioButton.Checked)
                {
                    List<string> fileNames = new List<string>();
                    if (listView.SelectedItems.Count != 0)
                    {
                        for (int i = 0; i < listView.SelectedItems.Count; i++)
                        {
                            fileNames.Add(listView.SelectedItems[i].Text);
                        }
                        FolderBrowserDialog dialog = new FolderBrowserDialog();
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            DotNetZipHelper.ExtractFiles(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.User.userid}.zip"), fileNames, dialog.SelectedPath);
                            MessageBox.Show("Файлы успешно скачены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (ListViewItem item in listView.SelectedItems)
                        {
                            FtpHelper.DownloadFile($@"{dialog.SelectedPath}\{item.Text}", $"ftp://91.122.211.144:50021/{item.Text}", CurrentUser.User.userid, CurrentUser.User.passwd);
                        }
                        MessageBox.Show("Файлы успешно скачены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void serverRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
            ChangeEnabledButtons();
        }

        private void localRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
            ChangeEnabledButtons();
        }
    }
}
