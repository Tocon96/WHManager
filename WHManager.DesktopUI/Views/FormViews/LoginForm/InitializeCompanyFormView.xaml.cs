using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.DesktopUI.Views.FormViews.LoginForm
{
    /// <summary>
    /// Interaction logic for InitializeCompanyFormView.xaml
    /// </summary>
    public partial class InitializeCompanyFormView : Window
    {
        IConfigService configService = new ConfigService();
        IUserService userService = new UserService();
        IRoleService roleService = new RoleService();
        public InitializeCompanyFormView()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void InitializeClick(object sender, RoutedEventArgs e)
        {
            if (Initialize())
            {
                LoginFormView loginFormView = new LoginFormView();
                loginFormView.Show();
                this.Close();
            }
        }

        private bool Initialize()
        {
            if (!roleService.CheckIfAdminRoleExists())
            {
                CreateAdminRole();
            }
            if (CreateAdminAccount())
            {
                if (InsertCompanyData())
                {
                    InitializeConfig();
                    return true;
                }
            }
            return false;
        }

        private bool CreateAdminAccount()
        {
            if (userService.CheckIfAdminExists())
            {
                return true;
            }


            if(textboxPassword.Password != "")
            {
                userService.CreateAdminUser(textboxPassword.Password);
                return true;
            }
            else
            {
                MessageBox.Show("Podaj hasło.");
                return false;
            }
            
        }

        private void CreateAdminRole()
        {
            roleService.CreateAdminRole();
        }

        private void InitializeConfig()
        {
            configService.InitializeConfig();
        }

        private bool InsertCompanyData()
        {
            IList<string> data = new List<string>();
            if(textBoxCompanyName.Text != "")
            {
                data.Add(textBoxCompanyName.Text);
            }
            else
            {
                MessageBox.Show("Podaj nazwę firmy.");
                return false;
            }
            if (textBoxCompanyPhoneNumber.Text != "")
            {
                data.Add(textBoxCompanyPhoneNumber.Text);
            }
            else
            {
                MessageBox.Show("Podaj numer telefonu.");
                return false;
            }
            if (textBoxCompanyNip.Text != "")
            {
                data.Add(textBoxCompanyNip.Text);
            }
            else
            {
                MessageBox.Show("Podaj NIP firmy.");
                return false;
            }

            if (data.Any())
            {
                configService.AddCompanyData(data.ToList());
                return true;
            }
            else
            {
                MessageBox.Show("Podaj dane firmy");
                return false;
            }
            
        }
    }
}
