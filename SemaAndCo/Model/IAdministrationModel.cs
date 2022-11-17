using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaAndCo.Model
{
    interface IAdministrationModel
    {
        List<Users> ReturnUsers();
        List<Users> SearchUsersOrderBy(int skip, int pageSize);
        List<Users> UsersLoad();
        List<Users> SearchUsers(string search);
    }
}
