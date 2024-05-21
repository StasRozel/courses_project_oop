using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Поле 'Откуда' обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Поле 'Откуда' должно содержать не более 100 символов")]
        [RegularExpression(@"^[a-zA-ZА-Яа-я]+$", ErrorMessage = "Поле 'Откуда' должно содержать только буквы и цифры")]
        public string? From
        {
            get { return from; }
            set
            {
                from = value;
                OnPropertyChanged(nameof(From));
            }
        }

        [Required(ErrorMessage = "Поле 'Куда' обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Поле 'Куда' должно содержать не более 100 символов")]
        [RegularExpression(@"^[a-zA-ZА-Яа-я]+$", ErrorMessage = "Поле 'Куда' должно содержать только буквы и цифры")]
        public string? To
        {
            get { return to; }
            set
            {
                to = value;
                OnPropertyChanged(nameof(To));
            }
        }

        [Required(ErrorMessage = "Поле 'Время' обязательно для заполнения")]
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        [Required(ErrorMessage = "Поле 'Цена' обязательно для заполнения")]
        [Range(0, double.MaxValue, ErrorMessage = "Поле 'Цена' должно быть положительным числом")]
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        [Required(ErrorMessage = "Поле 'Номер поезда' обязательно для заполнения")]
        [Range(1, int.MaxValue, ErrorMessage = "Поле 'Номер поезда' должно быть положительным числом")]
        public int NumberTrain
        {
            get { return numberTrain; }
            set
            {
                numberTrain = value;
                OnPropertyChanged(nameof(NumberTrain));
            }
        }

        [StringLength(500, ErrorMessage = "Описание должно содержать не более 500 символов")]
        [RegularExpression(@"^[a-zA-ZА-Яа-я]+$", ErrorMessage = "Описание должно содержать только буквы и цифры")]
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        [Required(ErrorMessage = "Поле 'Тип' обязательно для заполнения")]
        [StringLength(100, ErrorMessage = "Поле 'Тип' должно содержать не более 100 символов")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Поле 'Тип' должно содержать только буквы и цифры")]
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged(nameof(Type));
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
