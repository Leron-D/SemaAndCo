using Ionic.Zip;
using Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

namespace SemaAndCo.Supporting
{
    public static class DotNetZipHelper
    {
        public static string CreateArchive(string archiveName,
        CompressionLevel compressionLevel = CompressionLevel.Default)
        {
            using (var zipFile = new ZipFile())
            {
                zipFile.CompressionLevel = compressionLevel;
                zipFile.Save(archiveName);
                return archiveName;
            }
        }

        public static void AppendZipToArchive(string archiveName,
            List<string> appendFiles, string password,
            CompressionLevel compressionLevel = CompressionLevel.Default)
        {
            var options = new ReadOptions();
            options.Encoding = Encoding.UTF8;
            using (var zipFile = ZipFile.Read(archiveName, options))
            {
                zipFile.AlternateEncodingUsage = ZipOption.Always;
                zipFile.AlternateEncoding = Encoding.UTF8;
                zipFile.Password = password;
                zipFile.CompressionLevel = compressionLevel;
                zipFile.AddFiles(appendFiles, "\\");
                zipFile.Save();
            }
        }

        public static void ExtractZip(string archiveName, string outFolder)
        {
            using (var zip = ZipFile.Read(archiveName))
            {
                foreach (var e in zip)
                {
                    e.Extract(outFolder, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        public static void DeleteFilesFromZip(string archiveName, string subArchive, List<string> filesToDelete, string password)
        {
            using (var zipFile = ReadSubZipWithPassword(archiveName, subArchive, password))
            {
                zipFile.Password = password;
                foreach (var e in filesToDelete)
                {
                    zipFile.RemoveEntry(e);
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    zipFile.Save(memoryStream);
                    memoryStream.Position = 0;
                    using (var outerZip = ReadZip(archiveName))
                    {
                        outerZip.UpdateEntry(subArchive, memoryStream);
                        outerZip.Save();
                    }
                }
            }
        }

        public static void RefreshPassword(string archiveName, string password)
        {
            using (var zipFile = ZipFile.Read(archiveName))
            {
                zipFile.Password = password;
            }
        }

        public static void GetInfoFiles(string archiveName, string subFileName, string fileName, string password)
        {
            using (var zipFile = ReadSubZipWithPassword(archiveName, subFileName, password))
            {
                ZipEntry zipEntry = zipFile.Entries.FirstOrDefault(z => Path.GetFileName(z.FileName) == fileName);
                string size = "";
                string creationTime = $"Создан: {zipEntry.CreationTime.ToString()}";
                string modifiedTime = $"Последнее изменение: {zipEntry.ModifiedTime.ToString()}";
                if (zipEntry.CompressedSize < 1024)
                    size = $"Размер файла: {zipEntry.CompressedSize} Б";
                if (zipEntry.CompressedSize >= 1024)
                    size = $"Размер файла: {Math.Round(zipEntry.CompressedSize / 1024d)} КБ";
                if ((zipEntry.CompressedSize / 1024) > 1024)
                    size = $"Размер файла: {Math.Round(zipEntry.CompressedSize / 1024 / 1024d)} МБ";
                MessageBox.Show($"Название файла: {Path.GetFileName(zipEntry.FileName)}\n{size}\n{creationTime}\n{modifiedTime}",
                                "Информация о файле", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        public static ZipFile ReadSubZipWithPassword(string fileName, string subFileName, string password)
        {
            using (var zip = ZipFile.Read(fileName))
            {
                zip.AlternateEncodingUsage = ZipOption.Always;
                zip.AlternateEncoding = Encoding.UTF8;
                ZipEntry entry = zip[subFileName];
                using (var subZip = ZipFile.Read(entry.ExtractToMemoryStreamWithPassword(password)))
                {
                    subZip.AlternateEncodingUsage = ZipOption.Always;
                    subZip.AlternateEncoding = Encoding.UTF8;
                    return subZip;
                }
            }
        }

        public static ZipFile ReadZip(string fileName)
        {
            using (var zip = ZipFile.Read(fileName))
            {
                return zip;
            }
        }

        public static MemoryStream ExtractToMemoryStreamWithPassword(this ZipEntry zipEntry, string password)
        {
            var mstream = new MemoryStream();
            zipEntry.ExtractWithPassword(mstream, password);
            mstream.Position = 0;
            return mstream;
        }

        public static void AppendFilesToZip(string archiveName, string subArchive, List<string> filesName, string password)
        {
            using (ZipFile zip = ReadSubZipWithPassword(archiveName, subArchive, password))
            {
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.Password = password;
                foreach (var item in filesName)
                {
                    zip.AddFile(item, "");
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    zip.Save(memoryStream);
                    memoryStream.Position = 0;
                    using (var outerZip = ReadZip(archiveName))
                    {
                        outerZip.UpdateEntry(subArchive, memoryStream);
                        outerZip.Save();
                    }
                }
            }
        }

        //private void EncryptFile(string inputFile, string outputFile, string password)
        //{
        //    UnicodeEncoding UE = new UnicodeEncoding();
        //    byte[] key = CreateKey(password);

        //    string cryptFile = outputFile;
        //    FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

        //    RijndaelManaged RMCrypto = new RijndaelManaged();
        //    IV = CreateIV(password);

        //    CryptoStream cs = new CryptoStream(fsCrypt,
        //        RMCrypto.CreateEncryptor(key, IV),
        //        CryptoStreamMode.Write);

        //    FileStream fsIn = new FileStream(inputFile, FileMode.Open);

        //    int data;
        //    while ((data = fsIn.ReadByte()) != -1)
        //        cs.WriteByte((byte)data);


        //    fsIn.Close();
        //    cs.Close();
        //    fsCrypt.Close();
        //}

        //private void DecryptFile(string inputFile, string outputFile, string password)
        //{
        //    UnicodeEncoding UE = new UnicodeEncoding();
        //    byte[] key = CreateKey(password);
        //    FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
        //    RijndaelManaged RMCrypto = new RijndaelManaged();
        //    IV = CreateIV(password);

        //    CryptoStream cs = new CryptoStream(fsCrypt,
        //        RMCrypto.CreateDecryptor(key, IV),
        //        CryptoStreamMode.Read);

        //    FileStream fsOut = new FileStream(outputFile.Remove(outputFile.Length - 4), FileMode.Create);

        //    int data;
        //    while ((data = cs.ReadByte()) != -1)
        //        fsOut.WriteByte((byte)data);

        //    fsOut.Close();
        //    cs.Close();
        //    fsCrypt.Close();

        //}

        private static int saltLengthLimit = 32;
        private static byte[] GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }
        public static byte[] CreateKey(string password)
        {
            var salt = GetSalt(10);

            int iterationCount = 20000; // Nowadays you should use at least 10.000 iterations
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterationCount))
                return rfc2898DeriveBytes.GetBytes(16);
        }

        public static byte[] CreateIV(string password)
        {
            var salt = GetSalt(9);

            const int Iterations = 325;
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations))
                return rfc2898DeriveBytes.GetBytes(16);
        }

        public static void RenameZipEntries(string archiveName, string subArchiveName, string password, string fileName, string newName)
        {
            using (ZipFile zip = ReadSubZipWithPassword(archiveName, subArchiveName, password))
            {
                zip.Password = password;
                foreach (ZipEntry e in zip.ToList())
                {
                    if (e.FileName == fileName)
                        e.FileName = newName;
                }
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    zip.Save(memoryStream);
                    memoryStream.Position = 0;
                    using (var outerZip = ReadZip(archiveName))
                    {
                        outerZip.UpdateEntry(subArchiveName, memoryStream);
                        outerZip.Save();
                    }
                }
            }
        }
    }
}
