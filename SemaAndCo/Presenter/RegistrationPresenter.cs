using SemaAndCo.Model;
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
using static System.Net.WebRequestMethods;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace SemaAndCo.Presenter
{
    class RegistrationPresenter
    {
        Core context = new Core(Core.StrConnection());
        IRegistrationView view;
        SendMail sendMail;

        public RegistrationPresenter(IRegistrationView view)
        {
            this.view = view;
            sendMail = new SendMail();
        }

        public void RegistrationMethod(string login, string email, string name, string phone, string password, string repeatPassword)
        {
            try
            {
                if (Core.CheckAddingUserVariability())
                    AddNewUserMethod(login, email, name, phone, password, repeatPassword);
                else
                    RegistrationUserMethod(login, email, name, phone, password, repeatPassword);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RegistrationUserMethod(string login, string email, string name, string phone, string password, string repeatPassword)
        {
            try
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                var resultLog = context.semaandcouser.FirstOrDefault(u => u.userid == login);
                if (!String.IsNullOrWhiteSpace(login) && login.Length >= 5 && login.Length <= 30 && !String.IsNullOrWhiteSpace(password) && password.Length >= 5 && password.Length <= 30)
                {
                    if (password == repeatPassword)
                    {
                        if (!String.IsNullOrEmpty(email))
                        {
                            if (match.Success)
                            {
                                var resultEmail = context.semaandcouser.FirstOrDefault(r => r.email == email);
                                if (resultLog == null)
                                {
                                    if (resultEmail == null)
                                    {
                                        RegistrationData.login = login;
                                        RegistrationData.email = email;
                                        RegistrationData.name = name;
                                        RegistrationData.phone = phone;
                                        RegistrationData.password = password;
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
                                    throw new Exception("Пользователь с таким логином уже существует");
                            }
                            else
                                throw new Exception("Ввёден некорректный E-mail");
                        }
                        else
                            throw new Exception("Не введён E-mail");
                    }
                    else
                        throw new Exception("Поля ввода пароля и подтверждения пароля не совпадают");
                }
                else
                    throw new Exception("Логин и(или) пароль введён(-ены) некорректно");
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddNewUserMethod(string login, string email, string name, string phone, string password, string repeatPassword)
        {
            try
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                var resultLog = context.semaandcouser.FirstOrDefault(u => u.userid == login);
                if (login != "" && login.Length >= 5 && login.Length <= 30 && password.Length >= 5 && password.Length <= 30)
                {
                    if (password == repeatPassword)
                    {
                        if (!String.IsNullOrEmpty(email))
                        {
                            if (match.Success)
                            {
                                var resultEmail = context.semaandcouser.FirstOrDefault(r => r.email == email);
                                if (resultLog == null)
                                {
                                    if (resultEmail == null)
                                    {
                                        RegistrationData.login = login;
                                        RegistrationData.email = email;
                                        RegistrationData.name = name;
                                        RegistrationData.phone = phone;
                                        RegistrationData.password = password; RegistrationData.Registrate();
                                        MessageBox.Show("Пользователь успешно добавлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                        throw new Exception("Введенный Email уже существует в системе");
                                }
                                else
                                    throw new Exception("Пользователь с таким логином уже существует");
                            }
                            else
                                throw new Exception("Ввёден некорректный E-mail");
                        }
                        else
                            throw new Exception("Не введён E-mail");
                    }
                    else
                        throw new Exception("Поля ввода пароля и подтверждения пароля не совпадают");
                }
                else
                    throw new Exception("Логин и(или) пароль введён(-ены) некорректно");
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
