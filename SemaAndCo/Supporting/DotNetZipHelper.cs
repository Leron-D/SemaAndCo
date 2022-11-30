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
                zipFile.Save(Path.Combine(Properties.Settings.Default.savingPath, archiveName));
                return archiveName;
            }
        }

        public static void ExtractFiles(string archiveName, string fileName, string outFolder)
        {
            using (var zip = ZipFile.Read(archiveName))
            {
                zip.AlternateEncodingUsage = ZipOption.Always;
                zip.AlternateEncoding = Encoding.UTF8;
                foreach (ZipEntry e in zip)
                {
                    if (e.FileName == fileName)
                    {
                        e.Extract(outFolder, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
        }

        public static void DeleteFilesFromZip(string archiveName, List<string> filesToDelete)
        {
            using (var zipFile = ZipFile.Read(archiveName))
            {
                zipFile.RemoveEntries(filesToDelete);
                zipFile.Save();
            }
        }

        public static void GetInfoFiles(string archiveName, string fileName)
        {
            using (var zipFile = ZipFile.Read(archiveName))
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

        public static void AppendFilesToZip(string archiveName, string fileName)
        {
            using (ZipFile zip = ZipFile.Read(archiveName))
            {
                zip.AlternateEncodingUsage = ZipOption.Always;
                zip.AlternateEncoding = Encoding.UTF8;
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                zip.AddFile(fileName, "");
                zip.Save();
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
    }
}
