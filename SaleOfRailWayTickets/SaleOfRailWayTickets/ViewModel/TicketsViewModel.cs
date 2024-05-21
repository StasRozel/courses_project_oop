using lab4_5.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public TicketModel selectedTicket;

        public ObservableCollection<TicketModel>? Tickets { get; set; }

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
            string[] nameWay = ticketNameArr[0].Split("-");
            string errorStr = string.Empty;

            TicketModel newTicket = new TicketModel
            {
                Id = Tickets.Count() + 1,
                From = nameWay[0],
                To = nameWay[1],
                Description = ticketNameArr[1],
                NumberTrain = Convert.ToInt32(ticketNameArr[2]),
                Price = Convert.ToDouble(ticketNameArr[3]),
                Time = TimeSpan.Parse(ticketNameArr[4]),
                Type = Convert.ToBoolean(ticketNameArr[5]) ? "train" : "electric"
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(newTicket);
            if (!Validator.TryValidateObject(newTicket, context, results, true))
            {
                foreach (var error in results)
                {
                    errorStr += error.ErrorMessage + '\n';
                }
                MessageBox.Show(errorStr);
            }
            else
            {
                Tickets.Add(newTicket);

                UnitWorkContent.TicketRepository.Create(newTicket);
            }
                
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
            string[] nameWay = ticketNameArr[0].Split("-");
            string errorStr = string.Empty;

            TicketModel newTicket = new TicketModel
            {
                Id = Convert.ToInt32(ticketNameArr[0]),
                From = nameWay[0],
                To = nameWay[1],
                Description = ticketNameArr[2],
                NumberTrain = Convert.ToInt32(ticketNameArr[3]),
                Price = Convert.ToDouble(ticketNameArr[4]),
                Time = TimeSpan.Parse(ticketNameArr[5]),
                Type = Convert.ToBoolean(ticketNameArr[6]) ? "train" : "electric"
            };
            //Tickets[SelectedTicket.Id - 1] = newTicket;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(newTicket);
            if (!Validator.TryValidateObject(newTicket, context, results, true))
            {
                foreach (var error in results)
                {
                    errorStr += error.ErrorMessage + '\n';
                }
                MessageBox.Show(errorStr);
            }
            else
            {
                UnitWorkContent.TicketRepository.Update(newTicket);
            }


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
            TicketModel ticket = (TicketModel)parameter;

            Tickets?.Remove(ticket);

            UnitWorkContent.TicketRepository.Delete(ticket);

        }

        public TicketModel SelectedTicket
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
            Tickets = new ObservableCollection<TicketModel>(UnitWorkContent.TicketRepository.GetList());
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
