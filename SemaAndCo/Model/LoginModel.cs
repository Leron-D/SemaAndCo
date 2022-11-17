using SemaAndCo.Supporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaAndCo.Model
{
    class LoginModel : ILoginModel
    {
        public bool CheckConnection()
        {
            try
            {
                if (Core.Context.Users.AsNoTracking().ToList() != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Users LoginMethod(string login, string password)
        {
            try
            {
                Core.Context.Users.AsNoTracking().ToList();
                CurrentUser.User = Core.Context.Users.FirstOrDefault(c => c.Login == login && c.Password == password);
                if (CurrentUser.User != null)
                {
                    CurrentUser.User = Core.Context.Users.FirstOrDefault(c => c.Login == login && c.Password == password);
                    return CurrentUser.User;
                }
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
