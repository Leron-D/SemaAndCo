﻿using SemaAndCo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using SemaAndCo.Supporting;
using SemaAndCo.View;
using System.Runtime.Remoting.Contexts;

namespace SemaAndCo.Presenter
{
    class RegistrationPresenter
    {
        Core context = new Core(Core.StrConnection());
        IRegistrationModel model;
        IRegistrationView view;
        SendMail sendMail;

        public RegistrationPresenter(IRegistrationView view)
        {
            this.model = new RegistrationModel();
            this.view = view;
            sendMail = new SendMail();
        }

        public void RegistrationMethod(string login, string email, string name, string phone, string password, string repeatPassword)
        {
            try
            {
                RegistrationUserMethod(login, email, name, phone, password, repeatPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RegistrationUserMethod(string login, string email, string name, string phone, string password, string repeatPassword)
        {
            try
            {
                if (phone.Length == 11)
                {
                    if (login != "" && password != "" && password == repeatPassword && login.Length > 4 && password.Length > 4)
                    {
                        var resultLog = context.semaandcouser.FirstOrDefault(u => u.userid == login);
                        var resultEmail = context.semaandcouser.FirstOrDefault(r => r.email == email);
                        if (resultLog == null)
                        {
                            if (resultEmail == null)
                            {
                                RegistrationData.login = login;
                                RegistrationData.hash = "0f2ce17f1f5af3212ffde44976734c6b";
                                RegistrationData.email = email;
                                RegistrationData.name = name;
                                RegistrationData.phone = phone;
                                RegistrationData.password = CryptoClass.EncryptString(password);
                                if (sendMail.SendRegCode(email, false))
                                {
                                    view.Hide();
                                    Core.mailVariability = false;
                                    Core.addingUserVariability = false;
                                    AccessRecoveryForm form = new AccessRecoveryForm();
                                    form.ShowDialog();
                                    view.Close();
                                }
                            }
                            else
                                throw new Exception("Введенный Email уже существует в системе");
                        }
                        else
                            throw new Exception("Такой пользователь уже существует");
                    }
                    else
                        throw new Exception("Проверьте правильность ввода логина и пароля");
                }
                else
                    throw new Exception("Номер телефона введён некорректно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}