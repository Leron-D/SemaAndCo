using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemaAndCo.View;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace SemaAndCo.Model
{
    class AdministrationModel : IAdministrationModel
    {
        Core context = new Core(Core.StrConnection());
        List<FtpUser.semaandcouser> users;
        public List<FtpUser.semaandcouser> SearchUsersOrderBy(int skip, int pageSize)
        {
            return users.OrderBy(o => o.userid).Skip(skip).Take(pageSize).ToList();
        }
        public List<FtpUser.semaandcouser> SearchUsers(string search)
        {
            if (search == "")
            {
                return UsersLoad();
            }
            return users = users.Where(c => c.userid.Contains(search) || c.email.Contains(search) ||
                                       c.username.Contains(search) || c.phone.Contains(search)).ToList();
        }
        public List<FtpUser.semaandcouser> ReturnUsers()
        {
            return users;
        }
        public List<FtpUser.semaandcouser> UsersLoad()
        {
            users = context.semaandcouser.AsNoTracking().ToList();
            return users;
        }
    }
}
