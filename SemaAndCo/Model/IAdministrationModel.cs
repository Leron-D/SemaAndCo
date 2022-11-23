using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaAndCo.Model
{
    interface IAdministrationModel
    {
        List<FtpUser.semaandcouser> ReturnUsers();
        List<FtpUser.semaandcouser> SearchUsersOrderBy(int skip, int pageSize);
        List<FtpUser.semaandcouser> UsersLoad();
        List<FtpUser.semaandcouser> SearchUsers(string search);
    }
}
