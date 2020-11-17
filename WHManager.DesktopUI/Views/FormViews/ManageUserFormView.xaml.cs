using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DesktopUI.WindowSetting.Interfaces;
using WHManager.DesktopUI.WindowSetting;

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for ManageUserFormView.xaml
    /// </summary>
    public partial class ManageUserFormView : Window
    {
        public User User
        {
            get;
            set;
        }
        public ObservableCollection<Role> Roles
        {
            get;
            set;
        }
        private readonly IDisplaySetting displaySetting = new DisplaySetting();
        public ManageUserFormView()
        {
            InitializeComponent();
            displaySetting.CenterWindowOnScreen(this);
            comboboxRoles.ItemsSource = GetRoles();
        }
        public ManageUserFormView(User user)
        {
            InitializeComponent();
            displaySetting.CenterWindowOnScreen(this);
            User = user;
            comboboxRoles.ItemsSource = GetRoles();
            labelId.Content = user.Id;
            labelId.Visibility = Visibility.Visible;
        }

        private void ButtonAddUserClick(object sender, RoutedEventArgs e)
        {
            if(labelId.Visibility == Visibility.Hidden)
            {
                AddUser();
                this.Close();
            }
            else if(labelId.Visibility == Visibility.Visible)
            {
                UpdateUser();
                this.Close();
            }
        }

        private ObservableCollection<Role> GetRoles()
        {
            try
            {
                IRoleService roleService = new RoleService();
                IList<Role> roles = roleService.GetRoles();
                Roles = new ObservableCollection<Role>(roles);
                return Roles;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wczytywania ról: " + e);
                return null;
            }
        }
        public void AddUser()
        {
            try
            {
                IUserService userService = new UserService();
                User user = new User
                {
                    UserName = textBoxName.Text,
                    PasswordHash = textBoxPassword.Text,
                    Role = comboboxRoles.SelectedItem as Role
                };
                userService.AddUser(user);
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd dodawania: " + e);
            }
        }
        public void UpdateUser()
        {
            try
            {
                IUserService userService = new UserService();
                User user = new User
                {
                    Id = User.Id,
                    UserName = textBoxName.Text,
                    Role = comboboxRoles.SelectedItem as Role
                };
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd edytowania: " + e);
            }
        }
    }
}
