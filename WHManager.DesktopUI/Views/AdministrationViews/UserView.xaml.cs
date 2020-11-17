using Microsoft.EntityFrameworkCore.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DesktopUI.Views.FormViews;

namespace WHManager.DesktopUI.Views.AdministrationViews
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public ObservableCollection<User> Users
        {
            get;
            set;
        }
        public ObservableCollection<Role> Roles
        {
            get;
            set;
        }
        public UserView()
        {
            InitializeComponent();
            gridUsers.ItemsSource = LoadUsers();
            comboBoxSearchUnit.ItemsSource = GetRoles();
        }
        private void buttonAddUserClick(object sender, RoutedEventArgs e)
        {
            AddUserForm();
        }
        private void buttonUpdateUserClick(object sender, RoutedEventArgs e)
        {
            UpdateUserForm();
        }
        private void buttonDeleteUserClick(object sender, RoutedEventArgs e)
        {
            DeleteUser();
        }
        private void buttonSearchUserClick(object sender, RoutedEventArgs e)
        {
            if (radiobuttonId.IsChecked == true)
            {
                if (textboxSearchUnit.Text == "")
                {
                    gridUsers.ItemsSource = LoadUsers();
                }
                else
                {
                    gridUsers.ItemsSource = LoadUsersById(int.Parse(textboxSearchUnit.Text));
                }
            }
            else if(radiobuttonName.IsChecked == true)
            {
                gridUsers.ItemsSource = LoadUsersByName(textboxSearchUnit.Text);
            }
            else if(radiobuttonRole.IsChecked == true)
            {
                if (textboxSearchUnit.Text == "")
                {
                    gridUsers.ItemsSource = LoadUsers();
                }
                else
                {
                    Role role = comboBoxSearchUnit.SelectedItem as Role;
                    gridUsers.ItemsSource = LoadUsersByRole(role.Id);
                }
                
            }
        }
        private void buttonClearSearchUserClick(object sender, RoutedEventArgs e)
        {
            textboxSearchUnit.Text = null;
            gridUsers.ItemsSource = LoadUsers();
        }
        private IList<User> GetUsers()
        {
            try
            {
                IUserService userService = new UserService();
                IList<User> users = userService.GetUsers();
                return users;
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd wczytywania danych: " + e);
                return null;
            }

        }
        private IList<User> GetUsersById(int id)
        {
            try
            {
                IUserService userService = new UserService();
                IList<User> users = userService.GetUserById(id);
                return users;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wczytywania danych: " + e);
                return null;
            }
        }
        private IList<User> GetUsersByName(string name)
        {
            try
            {
                IUserService userService = new UserService();
                IList<User> users = userService.GetUsersByName(name);
                return users;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wczytywania danych: " + e);
                return null;
            }
        }
        private IList<User> GetUsersByRole(int id)
        {
            try
            {
                IUserService userService = new UserService();
                IList<User> users = userService.GetUsersByRole(id);
                return users;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wczytywania danych: " + e);
                return null;
            }
        }
        private ObservableCollection<User> LoadUsers()
        {
            try
            {
                Users = new ObservableCollection<User>(GetUsers());
                return Users;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania danych: " + e);
                return null;
            }
        }
        private ObservableCollection<User> LoadUsersById(int id)
        {
            try
            {
                Users = new ObservableCollection<User>(GetUsersById(id));
                return Users;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania danych: " + e);
                return null;
            }
        }
        private ObservableCollection<User> LoadUsersByName(string name)
        {
            try
            {
                Users = new ObservableCollection<User>(GetUsersByName(name));
                return Users;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania danych: " + e);
                return null;
            }
        }
        private ObservableCollection<User> LoadUsersByRole(int roleId)
        {
            try
            {
                Users = null;
                Users = new ObservableCollection<User>(GetUsersByRole(roleId));
                return Users;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wyświetlania danych: " + e);
                return null;
            }
        }
        private void DeleteUser()
        {
            try
            {
                if(gridUsers.SelectedItem != null)
                {
                    IUserService userService = new UserService();
                    User user = gridUsers.SelectedItem as User;
                    userService.DeleteUser(user.Id);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd usuwania: " + e);
            }
        }
        private void AddUserForm()
        {
            try
            {
                ManageUserFormView manageUserFormView = new ManageUserFormView();
                manageUserFormView.Show();
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd wywoływania formularza: " + e);
            }
        }
        private void UpdateUserForm()
        {
            try
            {
                User user = gridUsers.SelectedItem as User;
                ManageUserFormView manageUserFormView = new ManageUserFormView(user);
                manageUserFormView.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wywoływania formularza: " + e);
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
            catch(Exception e)
            {
                MessageBox.Show("Błąd wczytywania ról: "+ e);
                return null;
            }
        }
        private void radiobuttonIdClick(object sender, RoutedEventArgs e)
        {
            if(radiobuttonId.IsChecked == true)
            {
                textboxSearchUnit.Visibility = Visibility.Visible;
                comboBoxSearchUnit.Visibility = Visibility.Hidden;
            }
        }
        private void radiobuttonNameClick(object sender, RoutedEventArgs e)
        {
            if (radiobuttonName.IsChecked == true)
            {
                textboxSearchUnit.Visibility = Visibility.Visible;
                comboBoxSearchUnit.Visibility = Visibility.Hidden;
            }
        }
        private void radiobuttonRoleClick(object sender, RoutedEventArgs e)
        {
            if (radiobuttonRole.IsChecked == true)
            {
                textboxSearchUnit.Visibility = Visibility.Hidden;
                comboBoxSearchUnit.Visibility = Visibility.Visible;
            }
        }
    }
}