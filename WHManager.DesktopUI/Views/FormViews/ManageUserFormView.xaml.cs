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
using WHManager.DesktopUI.Views.AdministrationViews;

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

        private UserView UserGridView
        {
            get;
            set;
        }
        public ManageUserFormView(UserView userView)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            UserGridView = userView;
            comboboxRoles.ItemsSource = GetRoles();
            comboboxRoles.SelectedItem = Roles[0];
        }
        public ManageUserFormView(UserView userView, User user)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            User = user;
            UserGridView = userView;
            textBoxName.Text = user.UserName;
            comboboxRoles.ItemsSource = GetRoles();
            foreach (Role role in comboboxRoles.Items)
            {
                if (role.Id == user.Role.Id)
                {
                    comboboxRoles.SelectedItem = role;
                }
            }
            textBlockManageUser.Text = "Edytuj użytkownika ID: " + user.Id;
        }

        private void ButtonAddUserClick(object sender, RoutedEventArgs e)
        {
            if(User != null)
            {
                UpdateUser();
                DialogResult = true;
                this.Close();
            }
            else
            {
                AddUser();
                DialogResult = true;
                this.Close();
            }
        }

        public void OnDialogClose()
        {
            UserGridView.gridUsers.Items.Refresh();
        }

        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
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
                    PasswordHash = textBoxPassword.Password,
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
                    PasswordHash = textBoxPassword.Password,
                    Role = comboboxRoles.SelectedItem as Role
                };
                userService.UpdateUser(user);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd edytowania: " + e);
            }
        }

        private void textBoxName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBoxName.Clear();
        }

        private void textBoxPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBoxPassword.Clear();
        }

    }
}
