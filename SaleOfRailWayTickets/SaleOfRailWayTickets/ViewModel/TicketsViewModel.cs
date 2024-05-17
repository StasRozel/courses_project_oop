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
        public TicketEssence selectedTicket;

        public ObservableCollection<TicketEssence>? Tickets { get; set; }

        public UnitWorkContent UnitWorkContent { get; set; }

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

            string? ticketName = parameter as string;
            string[] ticketNameArr = ticketName.Split(',');

            TicketEssence newTicket = new TicketEssence
            {
                Id = Tickets.Count() + 1,
                NameWay = ticketNameArr[0],
                Description = ticketNameArr[1],
                NumberTrain = Convert.ToInt32(ticketNameArr[2]),
                Price = Convert.ToDouble(ticketNameArr[3]),
                Time = TimeSpan.Parse(ticketNameArr[4]),
                Type = Convert.ToBoolean(ticketNameArr[5]) ? "train" : "electric"
            };
            Tickets.Add(newTicket);

            UnitWorkContent.TicketRepository.Create(newTicket);
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

            TicketEssence newTicket = new TicketEssence
            {
                Id = Convert.ToInt32(ticketNameArr[0]),
                NameWay = ticketNameArr[1],
                Description = ticketNameArr[2],
                NumberTrain = Convert.ToInt32(ticketNameArr[3]),
                Price = Convert.ToDouble(ticketNameArr[4]),
                Time = TimeSpan.Parse(ticketNameArr[5]),
                Type = Convert.ToBoolean(ticketNameArr[6]) ? "train" : "electric"
            };
            //Tickets[SelectedTicket.Id - 1] = newTicket;

             UnitWorkContent.TicketRepository.Update(newTicket);

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
            TicketEssence ticket = (TicketEssence)parameter;

            Tickets?.Remove(ticket);

            UnitWorkContent.TicketRepository.Delete(ticket);

        }

        public TicketEssence SelectedTicket
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
            UnitWorkContent = new UnitWorkContent(new ApplicationDbContext());
            Tickets = new ObservableCollection<TicketEssence>(UnitWorkContent.TicketRepository.GetList());
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
