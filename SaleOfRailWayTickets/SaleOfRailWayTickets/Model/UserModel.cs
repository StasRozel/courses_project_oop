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

        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [Length(2, 20, ErrorMessage = "Имя должно быть от 2 до 20 символов")]
        [RegularExpression(@"^[a-zA-ZА-Яа-я]+$", ErrorMessage = "Имя состоит только из букв")]
        public string? FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        [Length(2, 40, ErrorMessage = "Фамилия должна быть от 2 до 40 символов")]
        [RegularExpression(@"^[a-zA-ZА-Яа-я]+$", ErrorMessage = "Фамилия состоит только из букв")]
        public string? LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        [Length(0, 20, ErrorMessage = "Отчество должно быть до 20 символов")]
        [RegularExpression(@"^[a-zA-ZА-Яа-я]+$", ErrorMessage = "Отчество состоит только из букв")]
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
        [Required(ErrorMessage = "Электронная почта обязательна для заполнения")]
        [EmailAddress(ErrorMessage = "Введите корректный адрес электронной почты")]
        public string? Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        //[Phone(ErrorMessage = "Введите корректный номер телефона")]
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
