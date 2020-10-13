using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WHManager.DesktopUI.Views.AdministrationViews;

namespace WHManager.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for AdministrationView.xaml
    /// </summary>
    public partial class AdministrationView : UserControl
    {
        public AdministrationView()
        {
            InitializeComponent();
            administrationContent.Content = new UserView();
        }

        private void UsersButtonClick(object sender, RoutedEventArgs e)
        {
            administrationContent.Content = new UserView();
        }

        private void RolesButtonClick(object sender, RoutedEventArgs e)
        {
            administrationContent.Content = new RoleView();
        }
    }
}