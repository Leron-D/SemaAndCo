using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemaAndCo.View;

namespace SemaAndCo.Model
{
    class AdministrationModel : IAdministrationModel
    {
        List<Users> users;
        public List<Users> SearchUsersOrderBy(int skip, int pageSize)
        {
            return users.OrderBy(o => o.Login).Skip(skip).Take(pageSize).ToList();
        }
        public List<Users> SearchUsers(string search)
        {
            if (search == "")
            {
                return UsersLoad();
            }
            return users = users.Where(c => c.Login.Contains(search) || c.Email.Contains(search) ||
                                       c.Name.Contains(search) || c.Phone.Contains(search)).ToList();
        }
        public List<Users> ReturnUsers()
        {
            return users;
        }
        public List<Users> UsersLoad()
        {
            users = Core.Context.Users.AsNoTracking().ToList();
            return users;
        }
    }
}
