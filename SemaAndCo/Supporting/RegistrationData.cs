using SemaAndCo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.Supporting
{
    class RegistrationData
    {
        public static string hash;
        public static string homedir;
        public static string login;
        public static string name;
        public static string email;
        public static string phone;
        public static string password;

        public static void Registrate()
        {
            try
            {
                FtpUser.semaandcouser user = new FtpUser.semaandcouser();
                Core context = new Core(Core.StrConnection());
                user.userid = login;
                user.hash = hash;
                user.homedir = homedir;
                user.email = email;
                user.username = name;
                user.phone = phone;
                user.passwd = CryptoClass.EncryptString(password);
                CurrentUser.User = user;
                context.semaandcouser.Add(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
