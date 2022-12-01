using Ionic.Zip;
using SemaAndCo.Model;
using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using ToolTip = System.Windows.Forms.ToolTip;

namespace SemaAndCo.View
{
    public partial class MainForm : TemplateForm
    {
        string saveText;
        string extension;
        bool fileResult;
        public MainForm()
        {
            InitializeComponent();
            ToolTip tool = new ToolTip();
            tool.SetToolTip(administrationButton, "Выход из аккаунта");
            tool.SetToolTip(exitButton, "Выход из аккаунта");
            if (CurrentUser.FtpUser == null)
                serverRadioButton.Visible = false;
            else
                serverRadioButton.Visible = true;
            if (CurrentUser.FtpUser != null)
            {
                CreateZip();
            }
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
            if (!System.IO.File.Exists(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip")))
            {
                DotNetZipHelper.CreateArchive($"{CurrentUser.FtpUser.userid}.zip");
            }
        }

        void LoadData()
        {
            listView.Items.Clear();
            if (localRadioButton.Checked)
            {
                if (CurrentUser.FtpUser != null)
                {
                    using (var zip = ZipFile.Read(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip")))
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
                    using (var zip = ZipFile.Read(Path.Combine(Properties.Settings.Default.savingPath, "autonom.zip")))
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
            }
            else
            {
                List<string> filesFromServer = FtpHelper.GetFilesList(@"ftp://91.122.211.144:50021/", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd);
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
                        try
                        {
                            List<string> filesForReplace = new List<string>();
                            foreach (string file in openFileDialog.FileNames)
                            {
                                if (LocalUser.LocalUsers == null)
                                {
                                    using (ZipFile zip = ZipFile.Read(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip")))
                                    {
                                        fileResult = zip.Any(entry => entry.FileName == Path.GetFileName(file));
                                    }
                                }
                                else
                                {
                                    using (ZipFile zip = ZipFile.Read(Path.Combine(Properties.Settings.Default.savingPath, "autonom.zip")))
                                    {
                                        fileResult = zip.Any(entry => entry.FileName == Path.GetFileName(file));
                                    }
                                }
                                if (fileResult)
                                {
                                    var messageResult = MessageBox.Show($"Файл с именем {Path.GetFileName(file)} уже существует. Вы хотите заменить его?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (messageResult == DialogResult.Yes)
                                    {
                                        filesForReplace.Clear();
                                        filesForReplace.Add(Path.GetFileName(file));
                                        if (LocalUser.LocalUsers == null)
                                        {
                                            DotNetZipHelper.DeleteFilesFromZip(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), filesForReplace);
                                            DotNetZipHelper.AppendFilesToZip(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), file);
                                        }
                                        else
                                        {
                                            DotNetZipHelper.DeleteFilesFromZip(Path.Combine(Properties.Settings.Default.savingPath, "autonom.zip"), filesForReplace);
                                            DotNetZipHelper.AppendFilesToZip(Path.Combine(Properties.Settings.Default.savingPath, "autonom.zip"), file);
                                        }
                                    }
                                }
                                else
                                {
                                    if(LocalUser.LocalUsers != null)
                                        DotNetZipHelper.AppendFilesToZip(Path.Combine(Properties.Settings.Default.savingPath, "autonom.zip"), file);
                                    else
                                        DotNetZipHelper.AppendFilesToZip(Path.Combine(Properties.Settings.Default.savingPath, "autonom.zip"), file);
                                }
                                    
                            }
                            MessageBox.Show("Файлы успешно загружены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        foreach (string file in openFileDialog.FileNames)
                        {
                            try
                            {
                                if (!FtpHelper.GetFilesList(@"ftp://91.122.211.144:50021/", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd).Contains(Path.GetFileName(file)))
                                {
                                    FtpHelper.UploadFile(file, $"ftp://91.122.211.144:50021/{Path.GetFileName(file)}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd);
                                }
                                else
                                {
                                    var message = MessageBox.Show($"Файл с именем {Path.GetFileName(file)} уже существует. Вы хотите заменить его?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if(message == DialogResult.Yes)
                                    {
                                        FtpHelper.DeleteFile($"ftp://91.122.211.144:50021/{Path.GetFileName(file)}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd);
                                        FtpHelper.UploadFile(file, $"ftp://91.122.211.144:50021/{Path.GetFileName(file)}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd);
                                        MessageBox.Show("Файл успешно заменён", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        MessageBox.Show("Файлы успешно загружены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            pictureBox.Visible = true;
            DeleteMethod();
            pictureBox.Visible = false;
            ChangeEnabledButtons();

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
                    if(LocalUser.LocalUsers == null)
                        DotNetZipHelper.DeleteFilesFromZip(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), filesToDelete);
                    else
                        DotNetZipHelper.DeleteFilesFromZip(Path.Combine(Properties.Settings.Default.savingPath, "autonom.zip"), filesToDelete);
                    MessageBox.Show("Файлы успешно удалены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        FtpHelper.DeleteFile($"ftp://91.122.211.144:50021/{item.Text}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd);
                    }                
                    MessageBox.Show("Файлы успешно удалены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (localRadioButton.Checked)
                {
                    if (listView.SelectedItems.Count == 1)
                    {
                        if(LocalUser.LocalUsers == null)
                            DotNetZipHelper.GetInfoFiles(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), listView.SelectedItems[0].Text);
                        else
                            DotNetZipHelper.GetInfoFiles(Path.Combine(Properties.Settings.Default.savingPath, $"autonom.zip"), listView.SelectedItems[0].Text);
                    }
                }
                else
                {
                    if (listView.SelectedItems.Count == 1)
                    {
                        FtpHelper.GetFileNameAndSize(listView.SelectedItems[0].Text, $"ftp://91.122.211.144:50021/{listView.SelectedItems[0].Text}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Hide();
            AuthorizationForm form = new AuthorizationForm();
            form.ShowDialog();
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
            CreateTextBoxToRename();
        }

        private void CreateTextBoxToRename()
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
            if(e.KeyCode == Keys.Enter)
            {
                RenameMethod(renameTextBox.Text, extension);
            }
        }

        private void RenameMethod(string fileName, string ext)
        {
            try
            {
                if (localRadioButton.Checked)
                {
                    using (var zip = ZipFile.Read(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip")))
                    {
                        var zipEntry = zip.Entries.FirstOrDefault(z => z.FileName == $"{renameTextBox.Text}.{extension}");
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
                                        entry.FileName = $"{fileName}.{ext}";
                                    zip.Save();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(fileName) && fileName != saveText.Remove(saveText.Length - extension.Length - 1))
                    {
                        FtpHelper.RenameFile($"{fileName}.{ext}", $"ftp://91.122.211.144:50021/{saveText}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd);
                    }
                }
                LoadData();
                listView.Enabled = true;
                renameButton.Enabled = renameTextBox.Visible = deleteButton.Enabled = infoButton.Enabled = downloadButton.Enabled = false;
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            pictureBox.Visible = true;
            DownloadMethod();
            pictureBox.Visible = false;
            ChangeEnabledButtons();
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
                        FolderBrowserDialog dialog = new FolderBrowserDialog();
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            for (int i = 0; i < listView.SelectedItems.Count; i++)
                            {
                                if (System.IO.File.Exists($@"{dialog.SelectedPath}\{listView.SelectedItems[i].Text}"))
                                {
                                    var messageResult = MessageBox.Show($"Файл с именем {listView.SelectedItems[i].Text} уже существует. Вы хотите заменить его?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (messageResult == DialogResult.Yes)
                                    {
                                        fileNames.Add(listView.SelectedItems[i].Text);
                                        DotNetZipHelper.ExtractFiles(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), listView.SelectedItems[i].Text, dialog.SelectedPath);
                                    }
                                }
                                else
                                {
                                    fileNames.Add(listView.SelectedItems[i].Text);
                                    DotNetZipHelper.ExtractFiles(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), listView.SelectedItems[i].Text, dialog.SelectedPath);
                                }
                            }
                            if (fileNames.Count > 0)
                            {
                                MessageBox.Show("Файлы успешно скачены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        List<string> listItems = new List<string>();
                        foreach (ListViewItem item in listView.SelectedItems)
                        {
                            if(System.IO.File.Exists($@"{dialog.SelectedPath}\{item.Text}"))
                            {
                                var messageResult = MessageBox.Show($"Файл с именем {item.Text} уже существует. Вы хотите заменить его?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (messageResult == DialogResult.Yes)
                                {
                                    listItems.Add(item.Text);
                                    FtpHelper.DownloadFile($@"{dialog.SelectedPath}\{item.Text}", $"ftp://91.122.211.144:50021/{item.Text}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd);
                                }
                            }
                            else
                            {
                                listItems.Add(item.Text);
                                FtpHelper.DownloadFile($@"{dialog.SelectedPath}\{item.Text}", $"ftp://91.122.211.144:50021/{item.Text}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd);
                            }

                        }
                        if(listItems.Count > 0)
                            MessageBox.Show("Файлы успешно скачены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox.Visible = true;
            LoadData();
            ChangeEnabledButtons();
            pictureBox.Visible = false;
        }
    }
}
