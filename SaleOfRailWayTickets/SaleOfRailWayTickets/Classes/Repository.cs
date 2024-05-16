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

namespace lab4_5.Classes
{
    public class Repository : IRepository<Ticket>
    {
        public static Ticket GetTicket(int id)
        {

            try
            {

                string pathTrain = "Resources/img/train.png";
                string pathElectric = "Resources/img/electric-train.png";

                string query = $"SELECT * FROM Tickets WHERE id = {id}";

                SqlCommand command = new SqlCommand(query, DBConnector.connection);
                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {

                    return new Ticket()
                    {
                        Id = reader.GetInt32(0),
                        NameWay = reader.GetString(1),
                        Time = reader.GetTimeSpan(2),
                        Price = reader.GetDouble(3),
                        NumberTrain = reader.GetInt32(4),
                        Description = reader.GetString(5),
                        Img = reader.GetString(6) == "train" ? pathTrain : pathElectric,
                        Type = reader.GetString(6)
                    };
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error get data to the database: {ex.Message}");
            }

            return new Ticket();
        }

        public static ObservableCollection<Ticket> GetTicketList()
        {

            try
            {
                ObservableCollection<Ticket> ticketList = new ObservableCollection<Ticket>();

                string pathTrain = "Resources/img/train.png";
                string pathElectric = "Resources/img/electric-train.png";

                string query = $"SELECT * FROM Tickets";

                SqlCommand command = new SqlCommand(query, DBConnector.connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ticketList.Add(new Ticket()
                    {
                        Id = reader.GetInt32(0),
                        NameWay = reader.GetString(1),
                        Time = reader.GetTimeSpan(2),
                        Price = reader.GetDouble(3),
                        NumberTrain = reader.GetInt32(4),
                        Description = reader.GetString(5),
                        Img = reader.GetString(6) == "train" ? pathTrain : pathElectric,
                        Type = reader.GetString(6)
                    });
                }
                return ticketList;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error get data to the database: {ex.Message}");
            }

            return new ObservableCollection<Ticket>();
        }

        public static void Create(Ticket ticket)
        { 
            try
            {
                string query = $"INSERT INTO Tickets (NameWay, [Time], Price, NumberTrain, [Description], [Type])" +
                            $"VALUES (@NameWay, @Time, @Price, @NumberTrain, @Description, @Type)";

                SqlCommand command = new SqlCommand(query, DBConnector.connection);

                command.Parameters.AddWithValue("@NameWay", ticket.NameWay);
                command.Parameters.AddWithValue("@Time", ticket.Time);
                command.Parameters.AddWithValue("@Price", ticket.Price);
                command.Parameters.AddWithValue("@NumberTrain", ticket.NumberTrain);
                command.Parameters.AddWithValue("@Description", ticket.Description);
                command.Parameters.AddWithValue("@Type", ticket.Type);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Ticket '{ticket.NameWay}' added successfully.");
                }
                else
                {
                    MessageBox.Show($"Failed to add ticket '{ticket.NameWay}'.");
                }

            }
            catch (SqlException ex) {
                MessageBox.Show(ex.Message );
            }
        }

        public static void Update(Ticket ticket)
        {
            SqlTransaction transaction = DBConnector.connection.BeginTransaction();
            try
            {
                string query = "UPDATE Tickets SET NameWay = @NameWay, [Description] = @Description, Price = @Price, NumberTrain = @NumberTrain, [Time] = @Time WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, DBConnector.connection);

                

                command.Parameters.AddWithValue("@NameWay", ticket.NameWay);
                command.Parameters.AddWithValue("@Time", ticket.Time);
                command.Parameters.AddWithValue("@NumberTrain", ticket.NumberTrain);
                command.Parameters.AddWithValue("@Description", ticket.Description);
                command.Parameters.AddWithValue("@Price", ticket.Price);
                command.Parameters.AddWithValue("@Id", ticket.Id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show($"Ticket with ID {ticket.Id} updated successfully.");
                    transaction.Commit();
                }
                else
                {
                    MessageBox.Show($"Failed to update ticket with ID {ticket.Id}.");
                }
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        public static void Delete(int id)
        {
            string query = $"DELETE FROM Tickets WHERE Id = @Id;";

            SqlCommand command = new SqlCommand(query, DBConnector.connection);
            command.Parameters.AddWithValue("@Id", id);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine($"Ticket with ID {id} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Failed to delete ticket with ID {id}.");
            }
        }

        public void Dispose() {}
    }
}
