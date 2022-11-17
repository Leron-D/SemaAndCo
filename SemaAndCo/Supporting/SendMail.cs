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

namespace SemaAndCo.Supporting
{
    public class SendMail
    {
        int code;
        bool success;
        public void EnterMail(string loginOrEmail)
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
                MessageBox.Show("Письмо с восстановлением пароля отправлено на ваш email. Проверьте почту.");
                Properties.Settings.Default.code = code;
                Properties.Settings.Default.Save();
                success = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public bool SendOnMail(string loginOrEmail)
        {
            try
            {
                var log = Core.Context.Users.FirstOrDefault(u => u.Login == loginOrEmail);
                var email = Core.Context.Users.FirstOrDefault(e => e.Email == loginOrEmail);
                Random rand = new Random();
                code = rand.Next(10000, 99999);
                if (log != null)
                {
                    loginOrEmail = log.Email;
                    EnterMail(loginOrEmail);
                    return success;
                }
                else if (email != null)
                {
                    EnterMail(loginOrEmail);
                    return success;
                }
                else
                    throw new Exception("Введенный логин или Email не существует в системе");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SendRegCode(string email)
        {
            try
            {
                Random rand = new Random();
                code = rand.Next(10000, 99999);
                EnterMail(email);
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
