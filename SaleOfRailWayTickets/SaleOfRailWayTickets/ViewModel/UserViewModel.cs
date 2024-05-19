using lab4_5.Classes;
using lab4_5.View;
using lab4_5.Pages;
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
using FluentValidation;
using FluentValidation.Results;
using lab4_5.Model;
using Microsoft.IdentityModel.Tokens;

namespace lab4_5.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private TicketModel selectedTicket;

        public UserModel AuthUser { get; set; }

        public UnitWorkContent UnitWorkContent { get; set; }

        private TicketCommand registrationCommand;
        private TicketCommand authorizationCommand;
        private TicketCommand saveConfigCommand;
       

        public TicketCommand RegistrationCommand
        {
            get
            {
                return registrationCommand ??
                  (registrationCommand = new TicketCommand(RegistrationUser, canExecuteTicket));
            }
        }

        private bool canExecuteTicket(object obj)
        {
            return true;
        }

        private void RegistrationUser(object parameter)
        {
            string? ticketName = parameter as string;
            string[] userNameArr = ticketName.Split(',');

            int pass = Convert.ToInt32(userNameArr[2]);
            int passDoub = Convert.ToInt32(userNameArr[3]);

            if (pass == passDoub)
            {
                UserModel newUser = new UserModel
                {
                    FirstName = userNameArr[0],
                    LastName = userNameArr[1],
                    Surname = "",
                    PasswordHash = PasswordHashing.Hash(userNameArr[2]),
                    Email = userNameArr[4],
                    PhoneNumber = "",
                    IsAdmin = false,

                };

                UnitWorkContent.UserRepository.Registration(newUser);

                App.session.AuthUser = newUser;

                ClientWindow clientWindow = new ClientWindow();
                App.session.clientWindow = clientWindow;
                clientWindow.Show();
                Registration.registration.Close();
            } else
            {
                MessageBox.Show("Пароли должны совпадать!");
            }
        }

        public TicketCommand AuthorizationCommand
        {
            get
            {
                return authorizationCommand ??
                  (authorizationCommand = new TicketCommand(AuthorizationUser, canExecuteTicket));
            }
        }

        private void AuthorizationUser(object parameter)
        {
            string email = Authorization.authorization.Email.Text;
            string password = Authorization.authorization.Password.Password;

            UserModel? authUser = UnitWorkContent.UserRepository.Authorization(PasswordHashing.Hash(password), email);

            App.session.AuthUser = authUser;

            if (authUser?.IsAdmin == true)
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                Authorization.authorization.Close();
            } else if (authUser?.IsAdmin == false)
            {
                ClientWindow clientWindow = new ClientWindow();
                App.session.clientWindow = clientWindow;
                clientWindow.Show();
                Authorization.authorization.Close();
            }
        }

        public TicketCommand SaveConfigCommand
        {
            get
            {
                return saveConfigCommand ??
                  (saveConfigCommand = new TicketCommand(SaveConfigUser, canExecuteTicket));
            }
        }

        private void SaveConfigUser(object parameter)
        {
            string firstName = Account.account.FirstName.Text;
            string lastName = Account.account.LastName.Text;
            string surname = Account.account.Surname.Text;
            string email = Account.account.Email.Text;
            string phoneNumber = Account.account.PhoneNumber.Text;

            string oldPassword = Account.account.OldPassword.Text;
            string newPassword = Account.account.NewPassword.Text;
            string newPasswordDouble = Account.account.NewPasswordDouble.Text;

            AuthUser.FirstName = firstName; AuthUser.LastName = lastName;
            AuthUser.Surname = surname; AuthUser.Email = email;
            AuthUser.PhoneNumber = phoneNumber;

            if (!oldPassword.IsNullOrEmpty() && !newPassword.IsNullOrEmpty() && 
                !newPasswordDouble.IsNullOrEmpty() && newPassword.Equals(newPasswordDouble))
            {
                AuthUser.PasswordHash = PasswordHashing.Hash(newPassword);
            }

            UnitWorkContent.UserRepository.Update(AuthUser);

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
                 
                    App.session.clientWindow?.MainFrame.Navigate( new OrderTicket(new PurchasedTicketViewModel(SelectedTicket, App.session.AuthUser)));
                }
                OnPropertyChanged("SelectedTicket");
            }
        }

        public UserViewModel()
        {
            UnitWorkContent = new UnitWorkContent(new ApplicationDbContext());
            AuthUser = App.session.AuthUser;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
