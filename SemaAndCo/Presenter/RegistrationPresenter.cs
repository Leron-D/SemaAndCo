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
                if (Core.CheckAddingUserVariability())
                    AddNewUserMethod(login, email, name, phone, password, repeatPassword);
                else
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
                if (login != "" && password != "" && password == repeatPassword && login.Length > 4 && password.Length > 4)
                {
                    var resultLog = context.semaandcouser.FirstOrDefault(u => u.userid == login);
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
                        throw new Exception("Такой пользователь уже существует");
                }
                else
                    throw new Exception("Проверьте правильность ввода логина и пароля");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddNewUserMethod(string login, string email, string name, string phone, string password, string repeatPassword)
        {
            try
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
                            RegistrationData.email = email;
                            RegistrationData.name = name;
                            RegistrationData.phone = phone;
                            RegistrationData.password = password;
                            RegistrationData.Registrate();
                            MessageBox.Show("Пользователь успешно добавлен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
