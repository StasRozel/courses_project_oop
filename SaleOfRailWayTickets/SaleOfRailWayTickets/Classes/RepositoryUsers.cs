using lab4_5.Classes;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab4_5
{
    public class RepositoryUsers
    {
       
        public static void Create(UserModel user)
        { 
            try
            {
                string query = $"INSERT INTO Users (FirstName, LastName, PasswordHach, Email, IsAdmin)" +
                            $"VALUES (@FirstName, @LastName, @PasswordHash, @Email, @IsAdmin)";

                SqlCommand command = new SqlCommand(query, DBConnector.connection);

                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@IsAdmin", 0);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Ticket '{user.FirstName} {user.LastName}' added successfully.");
                }
                else
                {
                    MessageBox.Show($"Failed to add ticket '{user.FirstName} {user.LastName}'.");
                }

            }
            catch (SqlException ex) {
                MessageBox.Show(ex.Message );
            }
        }

       
    }
}
