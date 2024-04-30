
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Windows;

namespace lab4_5
{
    public class JSONControl
    {
        public static ObservableCollection<Ticket>? Save(string path, Ticket ticket)
        {
            string file = File.ReadAllText(path);

            try
            {
                if (file != "")
                {
                    ObservableCollection<Ticket>? tickets = JsonConvert.DeserializeObject<ObservableCollection<Ticket>>(file);

                    tickets?.Add(ticket);

                    File.WriteAllText(path, JsonConvert.SerializeObject(tickets));

                }
                else
                {
                    throw new Exception("Файл пуст");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new ObservableCollection<Ticket>();
        }

        public static ObservableCollection<Ticket>? Load(string path)
        {
            string file = File.ReadAllText(path);

            try
            {
                if (file != "")
                {
                    return JsonConvert.DeserializeObject<ObservableCollection<Ticket>>(file);


                }
                else
                {
                    throw new Exception("Файл пуст");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new ObservableCollection<Ticket>();
        }

        public static void ChangeTicket(string path, Ticket ticket)
        {
            string file = File.ReadAllText(path);

            try
            {
                if (file != "")
                {
                    ObservableCollection<Ticket>? tickets = JsonConvert.DeserializeObject<ObservableCollection<Ticket>>(file);

                    Ticket? chageTicket = tickets?.ElementAt(ticket.Id - 1);

                    chageTicket.NameWay = ticket.NameWay;
                    chageTicket.Description = ticket.Description;
                    chageTicket.Price = ticket.Price;
                    chageTicket.NumberTrain = ticket.NumberTrain;
                    chageTicket.Time = ticket.Time;

                    File.WriteAllText(path, JsonConvert.SerializeObject(tickets));
                }
                else
                {
                    throw new Exception("Файл пуст");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void DeleteTicket(string path, int id)
        {
            string file = File.ReadAllText(path);

            try
            {
                if (file != "")
                {
                    ObservableCollection<Ticket>? tickets = JsonConvert.DeserializeObject<ObservableCollection<Ticket>>(file);

                    tickets?.RemoveAt(id - 1);

                    foreach (Ticket ticket1 in tickets)
                    {
                        if (id < ticket1.Id)
                        {
                            ticket1.Id = ticket1.Id - 1;
                        }
                    }

                    File.WriteAllText(path, JsonConvert.SerializeObject(tickets));
                }
                else
                {
                    throw new Exception("Файл пуст");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
