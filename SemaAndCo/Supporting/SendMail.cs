using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure.Interception;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using MySql.Data.MySqlClient;

namespace SemaAndCo.Supporting
{
    public class SendMail
    {
        Core context = new Core(Core.StrConnection());
        int code;
        bool success;
        public void EnterMailToRecoveryOrRegistration(string loginOrEmail, bool modif)
        {
            try
            {
                success = false;
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("sememshot2@yandex.ru", "СеменШот");
                // кому отправляем
                MailAddress to = new MailAddress(loginOrEmail);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Confirm your E-mail";
                // текст письма
                m.Body = $"<h2>Ваш код подтверждения:</h2><b>{code}</b>";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                smtp.EnableSsl = true;
                // логин и пароль
                smtp.Credentials = new NetworkCredential("sememshot2@yandex.ru", "Mamo4ka228");
                smtp.Send(m);
                if(modif)
                    MessageBox.Show("Письмо с кодом для восстановлением пароля отправлено на ваш email. Проверьте почту.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Письмо с кодом подтверждением отправлено на ваш email. Проверьте почту.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Properties.Settings.Default.code = code;
                Properties.Settings.Default.Save();
                success = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EnterMailWithChangesOfUser(string email, string message)
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("sememshot2@yandex.ru", "Администрация приложения SaC");
                // кому отправляем
                MailAddress to = new MailAddress(email);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Your data has been changed";
                // текст письма
                m.Body = $"{message}";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                smtp.EnableSsl = true;
                // логин и пароль
                smtp.Credentials = new NetworkCredential("sememshot2@yandex.ru", "Mamo4ka228");
                smtp.Send(m);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool SendMessageWithConfirmOnMail(string loginOrEmail, bool modif)
        {
            try
            {
                var log = context.semaandcouser.FirstOrDefault(u => u.userid == loginOrEmail);
                var email = context.semaandcouser.FirstOrDefault(e => e.email == loginOrEmail);
                Random rand = new Random();
                code = rand.Next(10000, 99999);
                if (log != null)
                {
                    loginOrEmail = log.email;
                    EnterMailToRecoveryOrRegistration(loginOrEmail, modif);
                    return success;
                }
                else if (email != null)
                {
                    EnterMailToRecoveryOrRegistration(loginOrEmail, modif);
                    return success;
                }
                else
                    throw new Exception("Введенный логин или Email не существует в системе");
            }
            catch (Exception ex)
            {
                if(ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутсвует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SendRegCode(string email, bool modif)
        {
            try
            {
                Random rand = new Random();
                code = rand.Next(10000, 99999);
                EnterMailToRecoveryOrRegistration(email, modif);
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
