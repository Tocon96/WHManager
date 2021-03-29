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
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.AuthenticationServices;
using WHManager.BusinessLogic.Services.AuthenticationServices.Interfaces;

namespace WHManager.DesktopUI.Views.FormViews.LoginForm
{
    /// <summary>
    /// Interaction logic for LoginFormView.xaml
    /// </summary>
    public partial class LoginFormView : Window
    {
        IAuthenticationService authenticationService = new AuthenticationService();
        public LoginFormView()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            User user = authenticationService.Login(textboxUserName.Text, textboxPassword.Password);
            try
            {
                if (user == null)
                {
                    MessageBox.Show("Błąd logowania");
                }
                else
                {
                    MainWindow mainWindow = new MainWindow(user);
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(""+ x);
            }
        }
    }
}