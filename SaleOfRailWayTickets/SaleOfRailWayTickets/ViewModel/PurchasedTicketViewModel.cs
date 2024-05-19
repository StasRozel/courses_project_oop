using FluentValidation.Results;
using lab4_5.Classes;
using lab4_5.Model;
using lab4_5.Pages;
using lab4_5.View;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab4_5.ViewModel
{
    public class PurchasedTicketViewModel : INotifyPropertyChanged
    {
        public TicketModel? selectedTicket;

        public ObservableCollection<TicketModel>? Tickets { get; set; }
        public ObservableCollection<PurchasedTicketModel>? PurchaseTickets { get; set; }
        public ObservableCollection<PurchasedTicketModel>? PurchaseTicketsDisplay { get; set; }

        private TicketModel buffSelectedTicket;
        private TicketCommand orderCommand;
        private TicketCommand paymentCommand;

        public UnitWorkContent UnitWorkContent { get; set; }


        public TicketCommand OrderCommand
        {
            get
            {
                return orderCommand ??
                  (orderCommand = new TicketCommand(OrderUser, canExecuteTicket));
            }
        }

        private bool canExecuteTicket(object obj)
        {
            return true;
        }

        private void OrderUser(object parameter)
        {
            ClientWindow? window = App.session.clientWindow;
            string errorStr = "";
            OrderTicket? orderTicket = window.MainFrame.Content as OrderTicket;
            FormOrder formOrder = new FormOrder
            {
                FirstName = orderTicket?.FirstNameTB.Text,
                LastName = orderTicket?.LastNameTB.Text,
                Surname = orderTicket?.SurnameTB.Text,
                TypeDoc = orderTicket?.TypeDocTB.Text,
                DocNumber = orderTicket?.DocNumberTB.Text,
                Agreement = orderTicket?.CheckAgreement.IsChecked
            };

            ValidatorFormOrder<FormOrder> validator = new ValidatorFormOrder<FormOrder>();

            ValidationResult results = validator.Validate(formOrder);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    errorStr += "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage + '\n';
                }
                MessageBox.Show(errorStr);
            }
            else
            {
                window?.MainFrame.Navigate(new PaymentByCard(orderTicket.DataContext));
            }
        }

        public TicketCommand PaymentCommand
        {
            get
            {
                return paymentCommand ??
                  (paymentCommand = new TicketCommand(PaymentUser, canExecuteTicket));
            }
        }

        private void PaymentUser(object parametr)
        {
            string errorStr = "";
            PaymentByCard? orderTicket = App.session.clientWindow?.MainFrame.Content as PaymentByCard;

            FormPayment formPayment = new FormPayment
            {
                NameHoldor = orderTicket?.NameHolderTB.Text,
                Validity = orderTicket?.ValidityTB.Text,
                NumberCard = orderTicket?.NumberCardTB.Text,
                CVV = orderTicket?.CVVTB.Text,
            };

            ValidatorFormPayment<FormPayment> validator = new ValidatorFormPayment<FormPayment>();

            ValidationResult results = validator.Validate(formPayment);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    errorStr += "Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage + '\n';
                }
                MessageBox.Show(errorStr);
            }
            else
            {
                UserModel userModel = App.session.AuthUser;

                PurchasedTicketModel purchasedTicket = new PurchasedTicketModel
                {
                    PurchaseId = (PurchaseTickets?.Count() ?? 0) + 1,
                    EmailUser = userModel.Email,
                    TicketId = buffSelectedTicket.Id,
                    From = buffSelectedTicket.From,
                    To = buffSelectedTicket.To,
                    PurchaseTime = buffSelectedTicket.Time,
                    Price = buffSelectedTicket.Price,
                    NumberTrain = buffSelectedTicket.NumberTrain,
                    Type = buffSelectedTicket.Type,
                };

                PurchaseTickets?.Add(purchasedTicket);

                UnitWorkContent.PurchasedTicketRepository.Create(purchasedTicket);
                App.session.clientWindow?.MainFrame.Navigate(new SuccessfulPurchase());
            }
        }

        public TicketModel SelectedTicket
        {
            get { return selectedTicket; }
            set
            {
                selectedTicket = value;
                if (SelectedTicket != null)
                {
                    //ClientWindow? window = App.Current.MainWindow as ClientWindow;

                    App.session.clientWindow?.MainFrame.Navigate(new OrderTicket(new PurchasedTicketViewModel(SelectedTicket, App.session.AuthUser)));
                }
                OnPropertyChanged("SelectedTicket");
            }
        }


        public PurchasedTicketViewModel(TicketModel ticketModel, UserModel user)
        {
            UnitWorkContent = new UnitWorkContent(new ApplicationDbContext());
            buffSelectedTicket = ticketModel;
            PurchaseTickets = new ObservableCollection<PurchasedTicketModel>(UnitWorkContent.PurchasedTicketRepository.GetList());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public PurchasedTicketViewModel()
        {
            UnitWorkContent = new UnitWorkContent(new ApplicationDbContext());
            
            PurchaseTicketsDisplay = new ObservableCollection<PurchasedTicketModel>(UnitWorkContent.PurchasedTicketRepository.GetList().Where(t => t.EmailUser == App.session.AuthUser.Email));
            Tickets = new ObservableCollection<TicketModel>(UnitWorkContent.TicketRepository.GetList());
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
