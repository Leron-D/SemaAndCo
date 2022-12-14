using MySql.Data.MySqlClient;
using SemaAndCo.Presenter;
using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.View
{
    public partial class RegistrationForm : Form, IRegistrationView
    {
        RegistrationPresenter presenter;
        ReferenceForm referenceForm = new ReferenceForm();
        public RegistrationForm()
        {
            IntroForm form = new IntroForm(533);
            form.ShowDialog();
            InitializeComponent();
            if (Core.CheckAddingUserVariability())
            {
                Text = "Добавление нового пользователя";
                titleLabel.Text = "Добавление пользователя";
                registrationButton.Text = "Создать";
            }
            else
            {
                Text = "Регистрация";
                titleLabel.Text = "Добро пожаловать!";
                registrationButton.Text = "Зарегистрироваться";
            }
            presenter = new RegistrationPresenter(this);
            captcha.Renew();
            ToolTip tool = new ToolTip();
            tool.SetToolTip(referenceButton, "О программе");
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrateMethod();
                captcha.Renew();
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

        private void RegistrateMethod()
        {
            try
            {
                if (captcha.CheckText(captchaTextBox.Text))
                {
                    string phone = phoneNumberTextBox.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                    if (phone.Length == 1)
                    {
                        phone = null;
                        presenter.RegistrationMethod(loginTextBox.Text, emailTextBox.Text, userNameTextBox.Text, phone,
                                            passwordTextBox.Text, repeatPasswordTextBox.Text);
                    }
                    else if (phone.Length != 11)
                    {
                        MessageBox.Show("Номер телефона введён некорректно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        presenter.RegistrationMethod(loginTextBox.Text, emailTextBox.Text, userNameTextBox.Text, phone,
                                            passwordTextBox.Text, repeatPasswordTextBox.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Код из капчи не соответсвует введенному", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    captcha.Renew();
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    captcha.Renew();
                }
                else
                {
                    MessageBox.Show(ex.Message);
                    captcha.Renew();
                }
            }
        }

        private void EmailTextBox_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailTextBox.Text);
            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                regErrorProvider.SetError(emailTextBox, "Введите email");
            }
            else if (!match.Success)
            {
                regErrorProvider.SetError(emailTextBox, "Введите корректный email");
            }
            else
            {
                regErrorProvider.Clear();
            }
        }

        private void LoginTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(loginTextBox.Text))
            {
                regErrorProvider.SetError(loginTextBox, "Введите логин");
            }
            else if (loginTextBox.Text.Length < 5 || loginTextBox.Text.Length > 30)
            {
                regErrorProvider.SetError(loginTextBox, "Логин должен быть длиной от 5 до 30 символов");
            }
            else
            {
                regErrorProvider.Clear();
            }
        }

        private void PasswordTextBox_Validating(object sender, CancelEventArgs e)
        {
            if(String.IsNullOrEmpty(passwordTextBox.Text))
            {
                regErrorProvider.SetError(passwordTextBox, "Не введен пароль!");
            }
            else if (passwordTextBox.Text.Length < 5 || passwordTextBox.Text.Length > 30)
            {
                regErrorProvider.SetError(passwordTextBox, "Пароль должен быть длиной от 5 до 30 символов");
            }
            else
            {
                regErrorProvider.Clear();
            }
        }

        private void RepeatPasswordTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (repeatPasswordTextBox.Text != passwordTextBox.Text)
            {
                regErrorProvider.SetError(repeatPasswordTextBox, "Пароли не совпадают");
            }
            else
            {
                regErrorProvider.Clear();
            }   
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {                
            referenceForm.Close();
            if (!Core.CheckAddingUserVariability())
            {

                Hide();
                AuthorizationForm authorizationForm = new AuthorizationForm();
                authorizationForm.ShowDialog();
                Close();
            }
        }

        private void RenewButton_Click(object sender, EventArgs e)
        {
            captcha.Renew();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    RegistrateMethod();
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

        private void CaptchaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void ReferenceButton_Click(object sender, EventArgs e)
        {
            referenceButton.Enabled = registrationButton.Enabled = false;
            referenceForm.FormClosed += ReferenceForm_Closed;
            referenceForm.ShowDialog();
        }
        private void ReferenceForm_Closed(object sender, FormClosedEventArgs e)
        {
            referenceButton.Enabled = registrationButton.Enabled = true;
        }
    }
}
