using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Demo_APP.Data_Access_Layer
{
    public class DataEstablishment
    {
        private static DataEstablishment instance;
        public MySqlConnection connection;

        public static DataEstablishment Instance
        {
            get { if (instance == null) instance = new DataEstablishment(); return DataEstablishment.instance; }
            private set { DataEstablishment.instance = value; }
        }

        public void Establish()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                // Local host : Thường là 127.0.0.1
                builder.Server = "127.0.0.1";
                // Username của cái database trong mysql workbench nhe
                builder.UserID = "root";
                // Password của nó
                builder.Password = "SPiAi2001";
                // Tên database
                builder.Database = "bus_system";
                builder.SslMode = MySqlSslMode.None;
                connection = new MySqlConnection(builder.ToString());
                MessageBox.Show("Database connection successful");
            }
            catch
            {
                MessageBox.Show("Connection failed");
            }
        }
    }
}
