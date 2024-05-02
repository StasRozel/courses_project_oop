using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab4_5.Classes
{
    public class DBConnector
    {
        public static SqlConnection connection { get; set; }

        public static void Connect()
        {
            string serverName = "STAS";
            string databaseName = "TicketSystem";

            string connectionString = $@"Data Source={serverName};Initial Catalog={databaseName};Integrated Security=True;Encrypt=False;";

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}");
            }
        }

        public void Disconnect()
        {
            try
            {
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error desconnect to the database: {ex.Message}");
            }

        }
    }
}
