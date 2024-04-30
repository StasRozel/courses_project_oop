using lab4_5.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace lab4_5
{
    public partial class TicketsViewModel
    {
        private int countSortByPrice = 0;
        private int countSortByAlpfabet = 0;

        private TicketCommand sortTicketsByPrice;
        private TicketCommand sortTicketsByAlphabet;
        private TicketCommand searchTicket;
        private TicketCommand filterTicketsByTime;
        private TicketCommand displayAll;
        private TicketCommand displayTrain;
        private TicketCommand displayElectric;

        public TicketCommand SortTicketsByPrice
        {
            get
            {
                return sortTicketsByPrice ??
                    (sortTicketsByPrice = new TicketCommand(SortByPrice, canExecuteTicket));
            }
        }

        private void SortByPrice(object parameter)
        {
            List<Ticket> tickets = new List<Ticket>();

            countSortByPrice++;

            if (countSortByPrice % 2 == 1)
                tickets = new List<Ticket>(Tickets?.OrderBy(ticket => ticket.Price));
            else
                tickets = new List<Ticket>(Tickets?.OrderByDescending(ticket => ticket.Price));

            Tickets.Clear();

            foreach (Ticket ticket in tickets)
            {
                Tickets.Add(ticket);
            }
        }

        public TicketCommand SortTicketsByAlphabet
        {
            get
            {
                return sortTicketsByAlphabet ??
                    (sortTicketsByAlphabet = new TicketCommand(SortByAlphabet, canExecuteTicket));
            }
        }

        private void SortByAlphabet(object parameter)
        {
            List<Ticket> tickets = new List<Ticket>(Tickets);

            countSortByAlpfabet++;

            if (countSortByAlpfabet % 2 == 1)
                tickets = new List<Ticket>(Tickets?.OrderBy(ticket => ticket.NameWay));
            else
                tickets = new List<Ticket>(Tickets?.OrderByDescending(ticket => ticket.NameWay));

            Tickets.Clear();

            foreach (Ticket ticket in tickets)
            {
                Tickets.Add(ticket);
            }
        }

        public TicketCommand SearchTicket
        {
            get
            {
                return searchTicket ??
                    (searchTicket = new TicketCommand(Search, canExecuteTicket));
            }
        }

        private void Search(object parameter)
        {
            List<Ticket> tickets = new List<Ticket>(JSONControl.Load(Directory.GetCurrentDirectory() + "../../../../Resources/Json/ways.json"));

            TextBox searchElement = parameter as TextBox;

            if (searchElement.Text != "")
            {
                tickets = tickets.Where(t => Regex.IsMatch(t.NameWay, searchElement.Text)).ToList();
            }

            Tickets.Clear();

            foreach (Ticket ticket in tickets)
            {
                Tickets.Add(ticket);
            }
        }

        public TicketCommand FilterTicketsByTime
        {
            get
            {
                return filterTicketsByTime ??
                    (filterTicketsByTime = new TicketCommand(FilterByTime, canExecuteTicket));
            }
        }

        private void FilterByTime(object parameter)
        {
            List<Ticket> tickets = new List<Ticket>(JSONControl.Load(Directory.GetCurrentDirectory() + "../../../../Resources/Json/ways.json"));
            TextBox filterElement = parameter as TextBox;

            if (filterElement.Text != "")
            {
                string[] times = filterElement.Text.Split('-');
                TimeSpan startTime = TimeSpan.Parse(times[0]);
                TimeSpan endTime = TimeSpan.Parse(times[1]);

                tickets = tickets.Where(t => t.Time >= startTime && t.Time <= endTime).ToList();
            }

            Tickets.Clear();

            foreach (Ticket ticket in tickets)
            {
                Tickets.Add(ticket);
            }
        }

        public TicketCommand DisplayTicketsAll
        {
            get
            {
                return displayAll ??
                    (displayAll = new TicketCommand(DisplayAll, canExecuteTicket));
            }
        }

        private void DisplayAll(object parameter)
        {
            List<Ticket> tickets = new List<Ticket>();

            RadioButton filterElement = parameter as RadioButton;

            if (filterElement?.IsChecked == true)
            {
                tickets = new List<Ticket>(JSONControl.Load(Directory.GetCurrentDirectory() + "../../../../Resources/Json/ways.json"));
            }

            Tickets?.Clear();

            foreach (Ticket ticket in tickets)
            {
                Tickets?.Add(ticket);
            }
        }

        public TicketCommand DisplayTicketsTrain
        {
            get
            {
                return displayTrain ??
                    (displayTrain = new TicketCommand(DisplayTrain, canExecuteTicket));
            }
        }

        private void DisplayTrain(object parameter)
        {
            List<Ticket> tickets = new List<Ticket>(JSONControl.Load(Directory.GetCurrentDirectory() + "../../../../Resources/Json/ways.json"));
            RadioButton filterElement = parameter as RadioButton;

            if (filterElement?.IsChecked == true)
            {
                tickets = tickets.Where(t => t.Type == "train").ToList();
            }

            Tickets?.Clear();

            foreach (Ticket ticket in tickets)
            {
                Tickets?.Add(ticket);
            }
        }

        public TicketCommand DisplayTicketsElectric
        {
            get
            {
                return displayElectric ??
                    (displayElectric = new TicketCommand(DisplayElectric, canExecuteTicket));
            }
        }

        private void DisplayElectric(object parameter)
        {
            List<Ticket> tickets = new List<Ticket>(JSONControl.Load(Directory.GetCurrentDirectory() + "../../../../Resources/Json/ways.json"));
            RadioButton filterElement = parameter as RadioButton;

            if (filterElement?.IsChecked == true)
            {
                tickets = tickets.Where(t => t.Type == "electric").ToList();
            }

            Tickets?.Clear();

            foreach (Ticket ticket in tickets)
            {
                Tickets?.Add(ticket);
            }
        }
    }
}
