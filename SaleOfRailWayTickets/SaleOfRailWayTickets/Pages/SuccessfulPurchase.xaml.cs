﻿using lab4_5.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4_5.Pages
{
    /// <summary>
    /// Логика взаимодействия для SuccessfulPurchase.xaml
    /// </summary>
    public partial class SuccessfulPurchase : Page
    {
        public SuccessfulPurchase()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow? window = App.session.clientWindow;

            if (window != null)
            {
                window.MainFrame.Content = new Home(new ViewModel.PurchasedTicketViewModel());
            }
        }
    }
}
