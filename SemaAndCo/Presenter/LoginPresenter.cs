using MySql.Data.MySqlClient;
using SemaAndCo.Model;
using SemaAndCo.Supporting;
using SemaAndCo.View;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.Presenter
{
    class LoginPresenter
    {
        ILoginModel model;
        ILoginView view;
        public LoginPresenter(ILoginView view)
        {
            this.model = new LoginModel();
            this.view = view;
        }

        public bool LoginMethod(string login, string password)
        {
            try
            {
                var user = model.LoginMethod(login, password.EncryptString());
                if (user != null)
                {
                    SaveAuthOptions();
                    CurrentUser.FtpUser = user;
                    return true;
                }
                else
                {
                    MessageBox.Show("Проверьте правильность ввода логина и пароля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }
        public void SaveAuthOptions()
        {
            if (view.SaveOptions)
            {
                Properties.Settings.Default.authLogin = view.Login;
                Properties.Settings.Default.password = view.Password;
            }
            else
            {
                Properties.Settings.Default.authLogin = "";
                Properties.Settings.Default.password = "";
            }
            Properties.Settings.Default.Save();
        }
    }
}
