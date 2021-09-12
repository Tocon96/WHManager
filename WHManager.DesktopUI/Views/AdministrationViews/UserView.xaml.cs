using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        IUserService userService = new UserService();
        public ObservableCollection<User> Users
        {
            get;
            set;
        }
        public ObservableCollection<string> Roles
        {
            get;
            set;
        }
        public UserView()
        {
            InitializeComponent();
            gridUsers.ItemsSource = LoadUsers();
            Roles = new ObservableCollection<string>(GetRoles());
            comboBoxRole.ItemsSource = Roles;
            comboBoxRole.SelectedItem = Roles[0];
        }
        private void AddUserClick(object sender, RoutedEventArgs e)
        {
            AddUserForm();
        }
        private void UpdateUserClick(object sender, RoutedEventArgs e)
        {
            UpdateUserForm();
        }
        private void DeleteUserClick(object sender, RoutedEventArgs e)
        {
            DeleteUser();
        }

        private void DeleteMultipleUserClick(object sender, RoutedEventArgs e)
        {
            DeleteMultipleUsers();
        }

        private void DeleteAllUserClick(object sender, RoutedEventArgs e)
        {
            DeleteAllUsers();
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {
            IList<User> users = SearchUsers();
            Users = new ObservableCollection<User>(users);
            gridUsers.ItemsSource = Users;
        }
        private void SearchClearClick(object sender, RoutedEventArgs e)
        {
            textBoxIdName.Text = null;
            comboBoxRole.SelectedItem = Roles[0];
            gridUsers.ItemsSource = LoadUsers();
        }
        private IList<User> GetUsers()
        {
            try
            {
                IList<User> users = userService.GetUsers();
                return users;
            }
            catch(Exception e)
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
        private void DeleteUser()
        {
            try
            {
                if(gridUsers.SelectedItem != null)
                {
                    User user = gridUsers.SelectedItem as User;
                    userService.DeleteUser(user.Id);
                }
                gridUsers.ItemsSource = LoadUsers();
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd usuwania: " + e);
            }
        }

        private void DeleteAllUsers()
        {
            try
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wszystkich użytkowników?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (User user in Users)
                        {
                            userService.DeleteUser(user.Id);
                        }
                        gridUsers.ItemsSource = LoadUsers();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd usuwania: " + e);
            }
        }

        private void DeleteMultipleUsers()
        {
            try
            {
                List<User> selectedUsers = gridUsers.SelectedItems.Cast<User>().ToList();
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybranych użytkowników?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (User user in selectedUsers)
                        {
                            userService.DeleteUser(user.Id);
                        }
                        gridUsers.ItemsSource = LoadUsers();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd usuwania: " + e);
            }
        }

        private void AddUserForm()
        {
            try
            {
                ManageUserFormView manageUserFormView = new ManageUserFormView(this);
                manageUserFormView.ShowDialog();
                if(manageUserFormView.DialogResult.Value == true)
                {
                    gridUsers.ItemsSource = LoadUsers();
                }
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
                ManageUserFormView manageUserFormView = new ManageUserFormView(this, user);
                manageUserFormView.ShowDialog();
                if (manageUserFormView.DialogResult.Value == true)
                {
                    gridUsers.ItemsSource = LoadUsers();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wywoływania formularza: " + e);
            }
        }
        private IList<string> GetRoles()
        {
            try
            {
                IRoleService roleService = new RoleService();
                IList<Role> allRoles = roleService.GetRoles();
                IList<string> roles = new List<string>();
                roles.Add("Wszystkie");
                foreach(Role role in allRoles)
                {
                    roles.Add(role.Name);
                }
                return roles;
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd wczytywania ról: "+ e);
                return null;
            }
        }
        private IList<User> SearchUsers()
        {
            List<string> criteria = new List<string>();
            criteria.Add(textBoxIdName.Text);                           //criteria[0] = Id/Name
            if(comboBoxRole.SelectedItem.ToString() == "Wszystkie")
            {
                criteria.Add("");                                       //criteria[1] = Role
            }
            else
            {
                criteria.Add(comboBoxRole.SelectedItem.ToString());     //criteria[1] = Role
            }
            IList<User> searchedUsers = userService.SearchUsers(criteria);
            return searchedUsers;
        }
    }
}