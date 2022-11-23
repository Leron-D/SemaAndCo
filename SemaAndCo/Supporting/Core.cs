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
        public static bool admClosed;
        static public string StrConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Database = "ftp";
            builder.UserID = "semaandcoadmin";
            builder.Password = "0f2ce17f1f5af3212ffde44976734c6b";
            builder.Server = "91.122.211.144";
            builder.Port = 53306;
            //builder.PersistSecurityInfo = true;
            //builder.CharacterSet = "utf8";
            //builder.SslMode = MySqlSslMode.Disabled;
            return builder.ConnectionString;
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Build();
        //    base.OnModelCreating(modelBuilder);
        //}
        public Core(string conStr) : base(new MySqlConnection(conStr), true)
        { }
        public DbSet<semaandcouser> semaandcouser { get; set; }

        //private static SacEntities context;



        //public static SacEntities Context
        //{
        //    get => context ?? (context = new SacEntities());
        //}

        //public static string Server { get => server; set => server = value; }
        //public static string Database { get => database; set => database = value; }
        //public static string Login { get => login; set => login = value; }
        //public static string Password { get => password; set => password = value; }

        //static string server = "DESKTOP-DK30NAS";
        //static string database = "SAC";
        //static string login = "sa";
        //static string password = "1";

        //public static void LoadConnectionString()
        //{
        //    SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder();
        //    sqlConnection.DataSource = server;
        //    sqlConnection.InitialCatalog = database;
        //    sqlConnection.UserID = login;
        //    sqlConnection.Password = password;
        //    Context.Database.Connection.ConnectionString = sqlConnection.ConnectionString;
        //}

        public static bool CheckClosed()
        {
            return admClosed;
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
