using MySql.Data.MySqlClient;
using SemaAndCo.Model;
using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.View
{
    public partial class ChangeUserForm : TemplateForm
    {
        string oldEmail;
        string oldPassword;
        string oldName;
        string oldPhone;
        string messageToEmail = "";
        Core context = new Core(Core.StrConnection());
        SendMail sendMail = new SendMail();
        FtpUser.semaandcouser user = new FtpUser.semaandcouser();
        public ChangeUserForm(string userid)
        {
            InitializeComponent();
            LoadForm(userid);
        }

        private void LoadForm(string userid)
        {
            user = context.semaandcouser.Where(u => u.userid == userid).FirstOrDefault();
            emailTextBox.Text = oldEmail = user.email;
            nameTextBox.Text = oldName = user.username;
            passwordTextBox.Text = oldPassword = user.passwd;
            phoneTextBox.Text = oldPhone = user.phone;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveChangesMethod();
        }

        private void SendMessageToUser(string password)
        {
            if (user.email != oldEmail)
                messageToEmail += $"<br>Ваш E-mail был изменён на <b>{user.email}</b>";
            if (user.username != oldName)
                messageToEmail += $"<br>Ваше имя было изменено на <b>{user.username}</b>";
            if (user.passwd != oldPassword)
                messageToEmail += $"<br>Ваш пароль был изменён на <b>{password}</b>";
            if (String.IsNullOrEmpty(user.phone))
                messageToEmail += "<br>Ваш телефон был удалён";
            else if (user.phone != oldPhone)
                messageToEmail += $"<br>Ваш телефон был изменён на <b>{user.phone}</b>";
            if(!String.IsNullOrEmpty(messageToEmail))
            {
                sendMail.EnterMailWithChangesOfUser(oldEmail, messageToEmail);
                MessageBox.Show("Данные пользователя успешно изменены. Пользователю отправлено сообщение с изменениями", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveChangesMethod()
        {
            try
            {
                if (String.IsNullOrEmpty(emailTextBox.Text))
                    throw new Exception("Поле email не заполнено");
                if (String.IsNullOrEmpty(passwordTextBox.Text))
                    throw new Exception("Поле пароля не заполнено");
                var message = MessageBox.Show($"Сохранить изменения?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (message == DialogResult.Yes)
                {
                    user.email = emailTextBox.Text;
                    user.username = nameTextBox.Text;
                    if(passwordTextBox.Text != oldPassword)
                        user.passwd = passwordTextBox.Text.EncryptString();
                    if (phoneTextBox.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Length == 1)
                        user.phone = null;
                    else
                        user.phone = phoneTextBox.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                    context.SaveChanges();
                    SendMessageToUser(passwordTextBox.Text);
                }
                Close();
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
