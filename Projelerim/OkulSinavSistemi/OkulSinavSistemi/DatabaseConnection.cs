using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulSinavSistemi
{
    internal class DatabaseConnection
    {
        private static SqlConnection _connection;

        // Mevcut bağlantı stringinizi buraya ekleyin
        private static string _connectionString = @"Data Source=TURKAN;Initial Catalog=SinavSistemiDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
