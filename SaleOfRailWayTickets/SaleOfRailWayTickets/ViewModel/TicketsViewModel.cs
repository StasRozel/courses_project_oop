using lab4_5.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace lab4_5
{
    public partial class TicketsViewModel : INotifyPropertyChanged
    {
        public Ticket selectedTicket;

        public ObservableCollection<Ticket>? Tickets { get; set; }

        private TicketCommand addCommand;
        private TicketCommand changeCommand;
        private TicketCommand deleteCommand;

        public TicketCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new TicketCommand(AddTicket, canExecuteTicket));
            }
        }

        private bool canExecuteTicket(object obj)
        {
            return true;
        }

        private void AddTicket(object parameter)
        {
            string ticketName = parameter as string;
            string[] ticketNameArr = ticketName.Split(',');
            string pathTrain = "Resources/img/train.png";
            string pathElectric = "Resources/img/electric-train.png";

            Ticket newTicket = new Ticket
            {
                Id = Tickets.Count + 1,
                NameWay = ticketNameArr[0],
                Description = ticketNameArr[1],
                NumberTrain = Convert.ToInt32(ticketNameArr[2]),
                Price = Convert.ToDouble(ticketNameArr[3]),
                Time = TimeSpan.Parse(ticketNameArr[4]),
                Img = Convert.ToBoolean(ticketNameArr[5]) ? pathTrain : pathElectric,
                Type = Convert.ToBoolean(ticketNameArr[5]) ? "train" : "electric"
            };
            Tickets.Add(newTicket);

            DataManager.AddTicketToTable(newTicket);
        }

        public TicketCommand ChangeCommand
        {
            get
            {
                return changeCommand ??
                  (changeCommand = new TicketCommand(ChangeTicketCommand, canExecuteTicket));
            }
        }

        private void ChangeTicketCommand(object parameter)
        {
            string? ticketName = parameter as string;
            string[] ticketNameArr = ticketName.Split(',');
            string pathTrain = "Resources/img/train.png";
            string pathElectric = "Resources/img/electric-train.png";

            Ticket newTicket = new Ticket
            {
                Id = Convert.ToInt32(ticketNameArr[0]),
                NameWay = ticketNameArr[1],
                Description = ticketNameArr[2],
                NumberTrain = Convert.ToInt32(ticketNameArr[3]),
                Price = Convert.ToDouble(ticketNameArr[4]),
                Time = TimeSpan.Parse(ticketNameArr[5]),
                Img = Convert.ToBoolean(ticketNameArr[6]) ? pathTrain : pathElectric,
                Type = Convert.ToBoolean(ticketNameArr[6]) ? "train" : "electric"
            };
            Tickets[SelectedTicket.Id - 1] = newTicket;

            DataManager.ChangeTicketToTable(newTicket);

        }

        public TicketCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new TicketCommand(DeleteTicket, canExecuteTicket));
            }
        }

        private void DeleteTicket(object parameter)
        {
            int id = (int)parameter;

            Tickets?.RemoveAt(id-1);

            DataManager.DeleteTicketToTable(id);
        }

        public Ticket SelectedTicket
        {
            get { return selectedTicket; }
            set
            {
                selectedTicket = value;
                if (SelectedTicket != null)
                {
                    ChangeTicket changeTicket = new ChangeTicket();
                    changeTicket.Closed += ChangeTicket_Closed;
                    changeTicket.Show();
                }
                OnPropertyChanged("SelectedTicket");
            }
        }


        private void ChangeTicket_Closed(object sender, EventArgs e)
        {
            SelectedTicket = null;
        }

        public TicketsViewModel()
        {
            DBConnector.Connect();
            Tickets = new ObservableCollection<Ticket>(DataManager.GetDataTable("Tickets"));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
