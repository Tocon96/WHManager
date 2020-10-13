using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.ViewModels;

namespace WHManager.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public User User
        {
            get;
            set;
        }
        public MainWindow(User user)
        {
            InitializeComponent();
            User = user;
            CheckRole();
            labelName.Content = user.UserName;
            mainContent.Content = new WarehouseViewModel();
        }

        private void WarehouseViewClick(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new WarehouseViewModel();
        }

        private void ContrahentViewClick(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new ContractorsViewModel();
        }

        private void BusinessViewClick(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new BusinessViewModel();
        }
        private void AdministrationViewClick(object sender, RoutedEventArgs e)
        {
            mainContent.Content = new AdministrationViewModel();
        }

        private void CheckRole()
        {
            if(User.Role.IsAdmin == false )
            {
                buttonAdministration.Visibility = Visibility.Hidden;
            }
        }
    }
}
