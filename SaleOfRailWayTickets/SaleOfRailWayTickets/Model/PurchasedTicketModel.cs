using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5.Model
{
    public class PurchasedTicketModel : INotifyPropertyChanged
    {
        private int purchaseId;
        private string? emailUser;
        private int ticketId;
        private string? from;
        private string? to;
        private TimeSpan purchaseTime;
        private double price;
        private int numberTrain;
        private int status;
        private string? type;

        public event PropertyChangedEventHandler? PropertyChanged;
        [Key]
        public int PurchaseId
        {
            get { return purchaseId; }
            set
            {
                purchaseId = value;
                OnPropertyChanged(nameof(PurchaseId));
            }
        }

        public string? EmailUser
        {
            get { return emailUser; }
            set
            {
                emailUser = value;
                OnPropertyChanged(nameof(EmailUser));
            }
        }

        public int TicketId
        {
            get { return ticketId; }
            set
            {
                ticketId = value;
                OnPropertyChanged(nameof(TicketId));
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

        public TimeSpan PurchaseTime
        {
            get { return purchaseTime; }
            set
            {
                purchaseTime = value;
                OnPropertyChanged(nameof(PurchaseTime));
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public int NumberTrain
        {
            get { return numberTrain; }
            set
            {
                numberTrain = value;
                OnPropertyChanged(nameof(NumberTrain));
            }
        }

        public string? Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public string? Img
        {
            get { return $"/Resources/img/{Type}.png"; }
        }

        public int Status 
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
