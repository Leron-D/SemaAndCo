using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemaAndCo.Model
{
    class LoginModel : ILoginModel
    {
        Core context = new Core(Core.StrConnection());
        public bool CheckConnection()
        {
            try
            {
                if (context.semaandcouser.AsNoTracking().ToList() != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public FtpUser.semaandcouser LoginMethod(string login, string password)
        {
            try
            {
                
                context.semaandcouser.AsNoTracking().ToList();
                CurrentUser.User = context.semaandcouser.FirstOrDefault(c => c.userid == login && c.passwd == password);
                if (CurrentUser.User != null)
                    return CurrentUser.User;
                else
                    return CurrentUser.User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
