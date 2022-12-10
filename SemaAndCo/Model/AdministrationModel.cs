using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemaAndCo.View;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SemaAndCo.Model
{
    class AdministrationModel : IAdministrationModel
    {
        Core context = new Core(Core.StrConnection());
        List<FtpUser.semaandcouser> users;
        List<FtpUser.semaandcouser> newUsers;
        public List<FtpUser.semaandcouser> SearchUsersOrderBy(int skip, int pageSize)
        {
            return users.OrderBy(o => o.userid).Skip(skip).Take(pageSize).ToList();
        }
        public List<FtpUser.semaandcouser> SearchUsers(string search)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(search))
                {
                    return UsersLoad();
                }
                else
                {
                    users = newUsers.Where(c => c.userid.Contains(search) || c.email.Contains(search) ||
                                               c.username.Contains(search)).ToList();
                    if (newUsers == null)
                        return null;
                    else
                        return users;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is MySqlException)
                {
                    MessageBox.Show("Отсутствует соединение с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
        public List<FtpUser.semaandcouser> ReturnUsers()
        {
            return users;
        }

        public List<FtpUser.semaandcouser> UsersLoad()
        {
            users = context.semaandcouser.AsNoTracking().ToList();
            newUsers = users;
            return users;
        }
    }
}
