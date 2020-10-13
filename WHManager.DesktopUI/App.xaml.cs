using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WHManager.DesktopUI.Views.FormViews.LoginForm;

namespace WHManager.DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoginFormView loginFormView = new LoginFormView();
            loginFormView.Show();
        }

    }
}
