using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaAndCo.Model
{
    public class FtpUser
    {
        [Table("semaandcouser")]
        public class semaandcouser
        {
            public int id { get; set; }
            public string homedir { get; set; }
            public string userid { get; set; }
            public string email { get; set; }
            public string passwd { get; set; }
            public string username { get; set; }
            public string phone { get; set; }
        }
    }
}
