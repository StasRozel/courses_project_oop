using FluentValidation.Results;
using lab4_5.Classes;
using lab4_5.Model;
using lab4_5.Pages;
using lab4_5.View;
using Microsoft.IdentityModel.Tokens;
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
using System.Windows.Threading;

namespace lab4_5.ViewModel
{
    public class PurchasedTicketViewModel : INotifyPropertyChanged
    {
        private static Timer? timerExpectedCheck;
        private static Timer? timerActivityCheck;

        public TicketModel? selectedTicket;

        public ObservableCollection<TicketModel>? Tickets { get; set; }
        public ObservableCollection<PurchasedTicketModel>? PurchaseTickets { get; set; }
        public ObservableCollection<PurchasedTicketModel>? PurchaseTicketsDisplay { get; set; }

        public ObservableCollection<PurchasedTicketModel>? ExpectedTickets { get; set; }
        public ObservableCollection<PurchasedTicketModel>? ActiveTickets { get; set; }
        public ObservableCollection<PurchasedTicketModel>? DeactiveTickets { get; set; }

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

        public void StartTimer()
        {
            timerExpectedCheck = new Timer(
                                callback: (state) => { CheckTimeExpectedTicket();  if (ActiveTickets?.Count() != 0) CheckTimeActiveTicket(); }, 
                                state: null, 
                                dueTime: 60000, 
                                period: 60000);
        }

        private void CheckTimeActiveTicket()
        {
            
            timerActivityCheck = new Timer(callback: ActiveToDeactive, state: null, dueTime: 60000, period: 60000);
        }


        private int currentIndex = 0;
        public void ActiveToDeactive(object? _ticket)
        {
            if (ActiveTickets == null || ActiveTickets.Count == 0) return;

            if (currentIndex >= ActiveTickets.Count)
                currentIndex = 0;

            PurchasedTicketModel? ticket = null;
            Application.Current.Dispatcher.Invoke(() =>
            {
                if (currentIndex < ActiveTickets.Count)
                {
                    ticket = ActiveTickets[currentIndex];
                }
            });

            if (ticket != null)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    ActiveTickets.Remove(ticket);
                    DeactiveTickets?.Add(ticket);
                    ticket.Status = -1;
                    UnitWorkContent.PurchasedTicketRepository.Update(ticket);
                });

                currentIndex++;
            }

            if (ActiveTickets.Count == 0)
            {
                timerActivityCheck?.Dispose();
            }
        }


        private void CheckTimeExpectedTicket()
        {
            DateTime currentTime = DateTime.Now;
            string timeString = currentTime.ToString("T");

            foreach (var ticket in new List<PurchasedTicketModel>(ExpectedTickets))
            {
                if (TimeSpan.Parse(timeString) >= ticket.PurchaseTime)
                {
                    DoSomething(ticket);

                    if (ExpectedTickets.Count() == 0)
                        timerExpectedCheck?.Dispose();
                    
                }
            }
        }


        public void DoSomething(PurchasedTicketModel ticket)
        {
        
            Application.Current.Dispatcher.Invoke(() =>
            {
                ExpectedTickets?.Remove(ticket);
                ActiveTickets?.Add(ticket);
                ticket.Status = 1;
                UnitWorkContent.PurchasedTicketRepository.Update(ticket);
            });
        }

        public TicketModel SelectedTicket
        {
            get { return selectedTicket; }
            set
            {
                selectedTicket = value;
                if (SelectedTicket != null)
                {
                    App.session.clientWindow?.MainFrame.Navigate(new OrderTicket(new PurchasedTicketViewModel(SelectedTicket, App.session.AuthUser)));
                }
                OnPropertyChanged("SelectedTicket");
            }
        }

        public PurchasedTicketViewModel()
        {
            UnitWorkContent = new UnitWorkContent(new ApplicationDbContext());

            PurchaseTicketsDisplay = new ObservableCollection<PurchasedTicketModel>(UnitWorkContent.PurchasedTicketRepository.GetList().Where(t => t.EmailUser == App.session.AuthUser.Email));

            ExpectedTickets = new ObservableCollection<PurchasedTicketModel>();
            ActiveTickets = new ObservableCollection<PurchasedTicketModel>();
            DeactiveTickets = new ObservableCollection<PurchasedTicketModel>();

            foreach (var item in PurchaseTicketsDisplay)
            {
                switch (item.Status)
                {
                    case -1: DeactiveTickets.Add(item); break;
                    case 0: ExpectedTickets.Add(item); break;
                    case 1: ActiveTickets.Add(item); break;
                }
            }

            Tickets = new ObservableCollection<TicketModel>(UnitWorkContent.TicketRepository.GetList());
        }


        public PurchasedTicketViewModel(TicketModel ticketModel, UserModel user)
        {
            UnitWorkContent = new UnitWorkContent(new ApplicationDbContext());
            buffSelectedTicket = ticketModel;
            PurchaseTickets = new ObservableCollection<PurchasedTicketModel>(UnitWorkContent.PurchasedTicketRepository.GetList());
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
