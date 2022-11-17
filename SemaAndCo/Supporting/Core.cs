using SemaAndCo.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemaAndCo.Supporting
{
    sealed class Core
    {
        private static SacEntities context;

        public static bool mailVariability;
        public static bool admClosed;

        public static SacEntities Context
        {
            get => context ?? (context = new SacEntities());
        }

        public static string Server { get => server; set => server = value; }
        public static string Database { get => database; set => database = value; }
        public static string Login { get => login; set => login = value; }
        public static string Password { get => password; set => password = value; }

        static string server = "DESKTOP-DK30NAS";
        static string database = "SAC";
        static string login = "sa";
        static string password = "1";

        public static void LoadConnectionString()
        {
            SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder();
            sqlConnection.DataSource = server;
            sqlConnection.InitialCatalog = database;
            sqlConnection.UserID = login;
            sqlConnection.Password = password;
            Context.Database.Connection.ConnectionString = sqlConnection.ConnectionString;
        }

        public static bool CheckClosed()
        {
            return admClosed;
        }

        public static bool CheckVariability()
        {
            return mailVariability;
        }
    }
}
