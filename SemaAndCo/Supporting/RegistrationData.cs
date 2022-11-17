using SemaAndCo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.Supporting
{
    class RegistrationData
    {
        public static string login;
        public static string name;
        public static string email;
        public static string phone;
        public static string password;

        public static void Registrate()
        {
            try
            {
                Users user = new Users();
                user.Login = login;
                user.Email = email;
                user.Name = name;
                user.Phone = phone;
                user.Password = password;
                CurrentUser.User = user;
                Core.Context.Users.Add(user);
                Core.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
