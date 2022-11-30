using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaAndCo.Model
{
    public class LocalUser
    {
        public LocalUser(string userId, string password)
        {
            UserId = userId;
            Password = password;
        }
        public static string UserId { get; set; }
        public static string Password { get; set; }
        public static List<LocalUser> LocalUsers { get; set; }
    }
}
