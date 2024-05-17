using lab4_5.Classes;
using lab4_5.View;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace lab4_5.ViewModel
{
    public class UserViewModel
    {
        public ObservableCollection<UserModel>? Users { get; set; }

        public UnitWorkContent UnitWorkContent { get; set; }

        private TicketCommand registrationCommand;
        private TicketCommand authorizationCommand;

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

            UserModel newUser = new UserModel
            {
                FirstName = userNameArr[0],
                LastName = userNameArr[1],
                PasswordHash = PasswordHashing.Hash(userNameArr[2]),
                Email = userNameArr[4],
                PhoneNumber = "",
                IsAdmin = false,

            };

            UnitWorkContent.UserRepository.Registration(newUser);
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
            string[] authParam = (parameter as string).Split(',');

            UserModel? user = UnitWorkContent.UserRepository.Authorization(PasswordHashing.Hash(authParam[0]), authParam[1]);

            MessageBox.Show($"Hello, {user?.FirstName}");

            if (user?.IsAdmin == true)
            {
                AdminPanel mainWindow = new AdminPanel();
                mainWindow.Show();
                Authorization.authorization.Close();
            }
        }

        public UserViewModel()
        {
            UnitWorkContent = new UnitWorkContent(new ApplicationDbContext());
        }
    }
}
