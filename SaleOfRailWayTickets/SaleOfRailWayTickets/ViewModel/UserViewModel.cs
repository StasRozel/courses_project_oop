using lab4_5.Classes;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace lab4_5.ViewModel
{
    public class UserViewModel
    {
        public ObservableCollection<UserModel>? Users { get; set; }

        private TicketCommand addCommand;

        public TicketCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new TicketCommand(AddUser, canExecuteTicket));
            }
        }

        private bool canExecuteTicket(object obj)
        {
            return true;
        }

        private void AddUser(object parameter)
        {
            string ticketName = parameter as string;
            string[] userNameArr = ticketName.Split(',');

            UserModel newUser = new UserModel
            {
                FirstName = userNameArr[0],
                LastName = userNameArr[1],
                PasswordHash = PasswordHashing.Hash(userNameArr[2]),
                Email = userNameArr[4],

            };

            RepositoryUsers.Create(newUser);
        }

        public UserViewModel()
        {
            DBConnector.Connect();
        }
    }
}
