using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace lab4_5
{
    public class TicketModel : INotifyPropertyChanged
    {
        private int id;
        private string? from;
        private string? to;
        private TimeSpan time;
        private double price;
        private int numberTrain;
        private string description;
        private string type;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string? From
        {
            get { return from; }
            set
            {
                from = value;
                OnPropertyChanged(nameof(From));
            }
        }

        public string? To
        {
            get { return to; }
            set
            {
                to = value;
                OnPropertyChanged(nameof(To));
            }
        }

        public TimeSpan Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public int NumberTrain
        {
            get { return numberTrain; }
            set
            {
                numberTrain = value;
                OnPropertyChanged("NumberTrain");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Img
        {
            get { return $"/Resources/img/{type}.png"; }
        }

        public string Print()
        {
            return $"Id: {Id}\n" +
                   $"Name Way: {From}-{To}\n" +
                   $"Time: {Time}\n" +
                   $"Price: {Price}\n" +
                   $"Number Train: {NumberTrain}\n" +
                   $"Description: {Description}";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
