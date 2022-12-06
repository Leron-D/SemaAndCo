using SemaAndCo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using static SemaAndCo.Model.FtpUser;

namespace SemaAndCo.Supporting
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    sealed class Core : DbContext
    {   
        public static bool mailVariability;
        public static bool addingUserVariability;
        public static bool goAdministration;
        public static bool access;
        public static string hash = "0f2ce17f1f5af3212ffde44976734c6b";

        static public string StrConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Database = "ftp";
            builder.UserID = "semaandcoadmin";
            builder.Password = "0f2ce17f1f5af3212ffde44976734c6b";
            builder.Server = "91.122.211.144";
            builder.Port = 53306;
            return builder.ConnectionString;
        }
        public Core(string conStr) : base(new MySqlConnection(conStr), true)
        { }
        public DbSet<semaandcouser> semaandcouser { get; set; }

        public static bool CheckAccess()
        {
            return access;
        }

        public static bool CheckMailVariability()
        {
            return mailVariability;
        }
        public static bool CheckAddingUserVariability()
        {
            return addingUserVariability;
        }

    }
}
