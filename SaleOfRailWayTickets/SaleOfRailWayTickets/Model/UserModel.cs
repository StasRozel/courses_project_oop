using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4_5
{
    public class UserModel : INotifyPropertyChanged
    {
        private string? firstName;
        private string? lastName;
        private string? surname;
        private string? passwordHash;
        private string? email;
        private string? phoneNumber;
        private bool isAdmin;

        public string? FirstName
        {
            get { return firstName; }
            set 
            { 
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string? LastName
        {
            get { return lastName; }
            set 
            { 
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string? Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string? PasswordHash
        {
            get { return passwordHash; }
            set 
            { 
                passwordHash = value;
                OnPropertyChanged("PasswordHash");
            }
        }

        [Key]
        public string? Email
        {
            get { return email; }
            set 
            { 
                email = value; 
                OnPropertyChanged("Email");
            }
        }       

        public string? PhoneNumber
        {
            get { return phoneNumber; }
            set 
            { 
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public bool IsAdmin
        {
            get { return isAdmin; }
            set 
            { 
                isAdmin = value;
                OnPropertyChanged("IsAdmin");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
