using Ionic.Zip;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Net;
using SemaAndCo.Model;
using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        bool connection;
        bool selectCloudStorage = false;
        string saveText;
        string extension;
        bool fileResult;
        string autonomPassword = "autonom".EncryptString();
        string autonomFilePath = Path.Combine(Properties.Settings.Default.savingPath, "autonom.zip");
        string ftpUrl = @"ftp://91.122.211.144:50021/";
        ToolTip toolTip = new ToolTip();
        public MainForm()
        {
            InitializeComponent();
            LoadForm();
        }

        private void LoadForm()
        {
            try
            {
                ToolTip tool = new ToolTip();
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
                tool.SetToolTip(connectionCheckLabel, "Подключение к серверному хранилищу присутствует");
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task CheckConnection()
        {
            timer.Stop();
            await Task.Run(() =>
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUrl);
                    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    request.Credentials = new NetworkCredential($"{CurrentUser.FtpUser.userid}.{Core.hash}", CurrentUser.FtpUser.passwd);
                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        connection = true;
                    }
                }
                catch (Exception)
                {
                    connection = false;
                }
            });
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
                DotNetZipHelper.CreateArchive($"{CurrentUser.FtpUser.userid}.zip", CurrentUser.FtpUser.userid.EncryptString());
            }
        }

        void LoadData()
        {
            listView.Items.Clear();
            try
            {
                if (localRadioButton.Checked)
                {
                    if (!LocalUser.Automatic)
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
                        using (var zip = ZipFile.Read(autonomFilePath))
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
                    List<string> filesFromServer = FtpHelper.GetFilesList(ftpUrl, CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd);
                    if (filesFromServer != null)
                    {
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
                    else
                    {
                        localRadioButton.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединенме с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    localRadioButton.Checked = true;
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void UploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox.Visible = true;
                if (!LocalUser.Automatic)
                {
                    await UploadDataAsync($"{CurrentUser.FtpUser.userid}.zip");
                }
                else
                {
                    await UploadDataAsync("autonom.zip");
                }
                pictureBox.Visible = false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    localRadioButton.Checked = true;
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task UploadDataAsync(string fileName)
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
                                using (ZipFile zip = ZipFile.Read(Path.Combine(Properties.Settings.Default.savingPath, fileName)))
                                {
                                    fileResult = zip.Any(entry => entry.FileName == Path.GetFileName(file));
                                }
                                if (fileResult)
                                {
                                    var messageResult = MessageBox.Show($"Файл с именем {Path.GetFileName(file)} уже существует. Вы хотите заменить его?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (messageResult == DialogResult.Yes)
                                    {
                                        filesForReplace.Clear();
                                        filesForReplace.Add(Path.GetFileName(file));
                                        if (!LocalUser.Automatic)
                                        {
                                            await Task.Run(()=>DotNetZipHelper.DeleteFilesFromZip(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), filesForReplace));
                                            await Task.Run(()=>DotNetZipHelper.AppendFilesToZip(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), file, CurrentUser.FtpUser.userid.EncryptString()));
                                        }
                                        else
                                        {
                                            await Task.Run(()=>DotNetZipHelper.DeleteFilesFromZip(autonomFilePath, filesForReplace));
                                            await Task.Run(()=>DotNetZipHelper.AppendFilesToZip(autonomFilePath, file, autonomPassword));
                                        }
                                    }
                                }
                                else
                                {
                                    if (LocalUser.Automatic)
                                        await Task.Run(()=>DotNetZipHelper.AppendFilesToZip(autonomFilePath, file, autonomPassword));
                                    else
                                        await Task.Run(()=>DotNetZipHelper.AppendFilesToZip(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), file, CurrentUser.FtpUser.userid.EncryptString()));
                                }
                            }
                            //MessageBox.Show("Файлы успешно загружены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            if (await Task.Run(()=>FtpHelper.GetFilesList(ftpUrl, CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd) == null))
                            {
                                localRadioButton.Checked = true;
                            }
                            else
                            {
                                if (!await Task.Run(()=>FtpHelper.GetFilesList(ftpUrl, CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd).Contains(Path.GetFileName(file))))
                                {
                                    await Task.Run(()=>FtpHelper.UploadFile(file, $"{ftpUrl}{Path.GetFileName(file)}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd));
                                }
                                else
                                {
                                    var message = MessageBox.Show($"Файл с именем {Path.GetFileName(file)} уже существует. Вы хотите заменить его?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (message == DialogResult.Yes)
                                    {
                                        await Task.Run(()=>FtpHelper.DeleteFile($"{ftpUrl}{Path.GetFileName(file)}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd));
                                        await Task.Run(()=>FtpHelper.UploadFile(file, $"{ftpUrl}{Path.GetFileName(file)}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd));
                                        //MessageBox.Show("Файл успешно заменён", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }
                    //MessageBox.Show("Файлы успешно загружены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox.Visible = true;
                await DeleteMethodAsync();
                pictureBox.Visible = false;
                ChangeEnabledButtons();
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    localRadioButton.Checked = true;
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DeleteMethodAsync()
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
                    if(!LocalUser.Automatic)
                        await Task.Run(()=>DotNetZipHelper.DeleteFilesFromZip(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), filesToDelete));
                    else
                        await Task.Run(()=>DotNetZipHelper.DeleteFilesFromZip(autonomFilePath, filesToDelete));
                    //MessageBox.Show("Файлы успешно удалены", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        if(await Task.Run(()=>FtpHelper.DeleteFile($"{ftpUrl}{item.Text}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd) == FtpStatusCode.ConnectionClosed))
                        {
                            localRadioButton.Checked = true;
                            throw new Exception("Отсутствует соединение с сервером");
                        }
                    }                
                    //MessageBox.Show("Файлы успешно удалены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData();
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    localRadioButton.Checked = true;
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                GetFileInfoAsync();
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    localRadioButton.Checked = true;
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetFileInfoAsync()
        {
            try
            {
                string fileName = listView.SelectedItems[0].Text;
                if (localRadioButton.Checked)
                {
                    if (listView.SelectedItems.Count == 1)
                    {
                        if (!LocalUser.Automatic)
                            DotNetZipHelper.GetFileInfo(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), fileName);
                        else
                            DotNetZipHelper.GetFileInfo(Path.Combine(Properties.Settings.Default.savingPath, $"autonom.zip"), fileName);
                    }
                }
                else
                {
                    if (listView.SelectedItems.Count == 1)
                    {
                        if(!FtpHelper.GetFileInfo(fileName, $"{ftpUrl}{fileName}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd))
                        {
                            localRadioButton.Checked = true;
                            pictureBox.Visible = false;
                            throw new WebException("Отсутствует соединение с сервером");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(ex.InnerException is WebException)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Hide();
            AuthorizationForm form = new AuthorizationForm();
            form.ShowDialog();
            Close();
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            try
            {
                CreateTextBoxToRename();
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    renameTextBox.Visible = false;
                    localRadioButton.Checked = true;
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
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
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (!localRadioButton.Checked)
                        localRadioButton.Checked = true;
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RenameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            renameTextBox.Width = renameTextBox.Text.Length * 9 + 30;
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (!LocalUser.Automatic)
                        await RenameMethodAsync(renameTextBox.Text, extension, $"{CurrentUser.FtpUser.userid}.zip");
                    else
                        await RenameMethodAsync(renameTextBox.Text, extension, "autonom.zip");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException is MySqlException)
                    {
                        MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        renameTextBox.Visible = false;
                        localRadioButton.Checked = true;
                    }
                    else
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task RenameMethodAsync(string fileName, string ext, string archiveName)
        {
            try
            {
                if (localRadioButton.Checked)
                {
                    using (var zip = ZipFile.Read(Path.Combine(Properties.Settings.Default.savingPath, archiveName)))
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
                        pictureBox.Visible = true;
                        if(!await Task.Run(()=>FtpHelper.RenameFile($"{fileName}.{ext}", $"{ftpUrl}{saveText}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd)))
                        {
                            pictureBox.Visible = false;
                            renameTextBox.Visible = false;
                            listView.Enabled = true;
                            localRadioButton.Checked = true;
                            throw new WebException("Отсутствует соединение с сервером");
                        }
                        pictureBox.Visible = false;
                    }
                }
                LoadData();
                listView.Enabled = true;
                renameButton.Enabled = renameTextBox.Visible = deleteButton.Enabled = infoButton.Enabled = downloadButton.Enabled = false;
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    renameTextBox.Visible = false;
                    localRadioButton.Checked = true;
                }
                else if (ex.InnerException is WebException)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox.Visible = true;
                await DownloadMethodAsync();
                pictureBox.Visible = false;
                ChangeEnabledButtons();
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    localRadioButton.Checked = true;
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DownloadMethodAsync()
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
                                        if(!LocalUser.Automatic)
                                            await Task.Run(()=>DotNetZipHelper.ExtractFiles(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), listView.SelectedItems[i].Text, dialog.SelectedPath));
                                        else
                                            await Task.Run(()=>DotNetZipHelper.ExtractFiles(autonomFilePath, listView.SelectedItems[i].Text, dialog.SelectedPath));
                                    }
                                }
                                else
                                {
                                    fileNames.Add(listView.SelectedItems[i].Text);
                                    await Task.Run(()=>DotNetZipHelper.ExtractFiles(Path.Combine(Properties.Settings.Default.savingPath, $"{CurrentUser.FtpUser.userid}.zip"), listView.SelectedItems[i].Text, dialog.SelectedPath));
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
                                    if(await Task.Run(()=>FtpHelper.DownloadFile($@"{dialog.SelectedPath}\{item.Text}", $"{ftpUrl}{item.Text}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd) == FtpStatusCode.ConnectionClosed))
                                    {
                                        localRadioButton.Checked = true;
                                        throw new Exception("Отсутствует соединение с сервером");
                                    }
                                }
                            }
                            else
                            {
                                listItems.Add(item.Text);
                                if (await Task.Run(()=>FtpHelper.DownloadFile($@"{dialog.SelectedPath}\{item.Text}", $"{ftpUrl}{item.Text}", CurrentUser.FtpUser.userid, CurrentUser.FtpUser.passwd) == FtpStatusCode.ConnectionClosed))
                                {
                                    localRadioButton.Checked = true;
                                    throw new Exception("Отсутствует соединение с сервером");
                                }
                            }

                        }
                        if(listItems.Count > 0)
                            MessageBox.Show("Файлы успешно скачены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    localRadioButton.Checked = true;
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //timer.Enabled = false;
                IntroForm introForm = new IntroForm();
                introForm.Show();
                await CheckConnection();
                if (!connection)
                {
                    introForm.Close();
                    selectCloudStorage = true;
                    localRadioButton.Checked = true;
                    LoadData();
                    timer.Start();
                    //throw new Exception("Отсутствует соединение с сервером");
                }
                else
                {
                    introForm.Close();
                    LoadData();
                    ChangeEnabledButtons();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LocalUser.Automatic = false;
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            if (selectCloudStorage)
            {
                await CheckConnection();
                if (connection)
                {
                    connectionCheckLabel.Location = new Point(1096, 573);
                    connectionCheckLabel.Text = "Соединено";
                    connectionCheckLabel.ForeColor = Color.Lime;
                    toolTip.RemoveAll();
                    toolTip.SetToolTip(connectionCheckLabel, "Подключение к серверному хранилищу присутствует");
                }
                else
                {
                    connectionCheckLabel.Location = new Point(1000, 573);
                    connectionCheckLabel.Text = "Соединение отсутствует";
                    connectionCheckLabel.ForeColor = Color.Red;
                    toolTip.RemoveAll();
                    toolTip.SetToolTip(connectionCheckLabel, "Подключение к серверному хранилищу отсутствует");
                }
                timer.Start();
            }
        }
    }
}
