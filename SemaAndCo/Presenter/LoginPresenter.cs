﻿using SemaAndCo.Model;
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

        public void LoginMethod()
        {
            try
            {
                var user = model.LoginMethod(view.Login, view.Password.EncryptString());
                if (user != null)
                {
                    SaveAuthOptions();
                    CurrentUser.User = user;
                    view.Hide();
                    MainForm form = new MainForm();
                    form.ShowDialog();
                    view.Close();
                }
                else
                    MessageBox.Show("Проверьте правильность ввода логина и пароля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Отсутствует подключение к БД", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
