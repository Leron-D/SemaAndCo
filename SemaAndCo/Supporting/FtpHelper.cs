using Ionic.Zip;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.Supporting
{
    public static class FtpHelper
    {
        public static string message;
        public static FtpStatusCode DownloadFile(string filename, string address, string login, string password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential($"{login}.{Core.hash}", password);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            responseStream.DecryptStream(fs, login.GetKey(16));
                        }
                    }
                    return response.StatusCode;
                }
            }
            catch (Exception)
            {
                return FtpStatusCode.ConnectionClosed;
            }

        }

        public static void RenameFile(string filename, string address, string login, string password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
                request.Credentials = new NetworkCredential($"{login}.{Core.hash}", password);
                request.Proxy = null;
                request.Method = WebRequestMethods.Ftp.Rename;
                request.RenameTo = filename;
                request.GetResponse().Close();
            }
            catch (WebException)
            {
                MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static bool GetFileInfo(string filename, string address, string login, string password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
                request.Credentials = new NetworkCredential($"{login}.{Core.hash}", password);
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                string size = "";
                if (response.ContentLength < 1024)
                    size = $"Размер файла: {response.ContentLength} Б";
                if (response.ContentLength >= 1024)
                    size = $"Размер файла: {Math.Round(response.ContentLength / 1024d)} КБ";
                if ((response.ContentLength / 1024) > 1024)
                    size = $"Размер файла: {Math.Round(response.ContentLength / 1024 / 1024d)} МБ";
                message = $"Название файла: {filename}\nРазмер файла: {size}\n";
                GetFileLastModificated(address, login, password);
                MessageBox.Show(message, "Информация о файле", MessageBoxButtons.OK, MessageBoxIcon.Information);
                request.GetResponse();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void GetFileLastModificated(string address, string login, string password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
                request.Credentials = new NetworkCredential($"{login}.{Core.hash}", password);
                request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                FtpWebResponse ftpResponse = (FtpWebResponse)request.GetResponse();
                message += $"Последнее изменение: {ftpResponse.LastModified}";
            }
            catch (Exception)
            {
                MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static FtpStatusCode UploadFile(string filename, string address, string login, string password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential($"{login}.{Core.hash}", password);
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        fs.EncryptStream(requestStream, login.GetKey(16));
                    }

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                    {
                        return response.StatusCode;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return FtpStatusCode.ConnectionClosed;
                }
                else if (ex.InnerException is WebException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return FtpStatusCode.ConnectionClosed;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return FtpStatusCode.CantOpenData;
                }
            }
        }

        public static List<string> GetFilesList(string address, string login, string password)
        {
            try
            {
                List<string> lines = new List<string>();
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = new NetworkCredential($"{login}.{Core.hash}", password);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            while (!reader.EndOfStream)
                            {
                                lines.Add(reader.ReadLine());
                            }
                        }
                    }
                }
                List<string> files = new List<string>();
                foreach (string line in lines)
                {
                    string[] tokens =
                        line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[8];
                    string permissions = tokens[0];

                    files.Add(name + (permissions[0] == 'd' ? "/" : ""));
                }
                return files;
            }
            catch (Exception)
            {
                MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public static FtpStatusCode DeleteFile(string address, string login, string password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(address);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential($"{login}.{Core.hash}", password);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return response.StatusCode;
                }
            }
            catch (Exception)
            {
                return FtpStatusCode.ConnectionClosed;
            }
        }
    }
}
