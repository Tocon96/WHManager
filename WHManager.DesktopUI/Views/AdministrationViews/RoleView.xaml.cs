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
    /// Interaction logic for RoleView.xaml
    /// </summary>
    public partial class RoleView : UserControl
    {
        IRoleService roleService = new RoleService();
        public ObservableCollection<Role> Roles
        {
            get;
            set;
        }
        public RoleView()
        {
            InitializeComponent();
            gridRoles.ItemsSource = LoadData();
        }
        private IList<Role> GetRoles()
        {
            try
            {
                IRoleService roleService = new RoleService();
                IList<Role> roles = roleService.GetRoles();
                return roles;
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd pobierania danych:" + e);
                return null;
            }
        }
        private ObservableCollection<Role> LoadData()
        {
            try
            {
                Roles = new ObservableCollection<Role>(GetRoles());
                return Roles;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wczytywania danych:" + e);
                return null;
            }
        }
        private void buttonSearchRoleClick(object sender, RoutedEventArgs e)
        {
            IList<Role> roles = SearchRoles();
            Roles = new ObservableCollection<Role>(roles);
            gridRoles.ItemsSource = Roles;
        }
        private void buttonClearSearchRoleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                textBoxIdName.Text = null;
                gridRoles.ItemsSource = LoadData();
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd czysczenia: " + x);
            }
        }
        private void buttonAddRoleClick(object sender, RoutedEventArgs e)
        {
            ManageRoleFormView roleFormView = new ManageRoleFormView(this);
            roleFormView.ShowDialog();
            if (roleFormView.DialogResult.Value == true)
            {
                gridRoles.ItemsSource = LoadData();
            }
        }
        private void buttonUpdateRoleClick(object sender, RoutedEventArgs e)
        {
            if (gridRoles.SelectedItem != null)
            {
                Role role = gridRoles.SelectedItem as Role;
                ManageRoleFormView roleFormView = new ManageRoleFormView(this, role);
                roleFormView.ShowDialog();
                if (roleFormView.DialogResult.Value == true)
                {
                    gridRoles.ItemsSource = LoadData();
                }
            }
            
        }
        private void buttonDeleteRoleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DeleteRole();
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd usuwania:" + x);
            }
        }

        private void DeleteMultipleRoleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DeleteMultipleRoles();
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania:" + x);
            }
        }

        private void DeleteAllRolesClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DeleteAllRoles();
            }
            catch (Exception x)
            {
                MessageBox.Show("Błąd usuwania:" + x);
            }
        }

        private IList<Role> GetRoleById(int id)
        {
            try
            {
                IRoleService roleService = new RoleService();
                IList<Role> roles = roleService.GetRoleById(id);
                return roles;
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd wczytywania danych:" + e);
                return null;
            }
        }
        private IList<Role> GetRolesByName(string name)
        {
            try
            {
                IList<Role> roles = roleService.GetRoleByName(name);
                return roles;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wczytywania danych:" + e);
                return null;
            }
        }
        private ObservableCollection<Role> LoadRolesById(int id)
        {
            try
            {
                Roles = new ObservableCollection<Role>(GetRoleById(id));
                return Roles;
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd wczytywania danych:" + e);
                return null;
            }
        }
        private ObservableCollection<Role> LoadRolesByName(string name)
        {
            try
            {
                Roles = new ObservableCollection<Role>(GetRolesByName(name));
                return Roles;
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd wczytywania danych:" + e);
                return null;
            }
        }
        private void DeleteRole()
        {
            if(gridRoles.SelectedItem != null)
            {
                try
                {
                    Role role = gridRoles.SelectedItem as Role;
                    roleService.DeleteRole(role.Id);
                    gridRoles.ItemsSource = LoadData();
                }
                catch(Exception e)
                {
                    MessageBox.Show("Błąd usuwania:" + e);
                }
            }
        }

        private void DeleteAllRoles()
        {
            try
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wszystkie role?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (Role role in Roles)
                        {
                            roleService.DeleteRole(role.Id);
                        }
                        gridRoles.ItemsSource = LoadData();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd usuwania: " + e);
            }
        }

        private void DeleteMultipleRoles()
        {
            try
            {
                List<Role> selectedRoles = gridRoles.SelectedItems.Cast<Role>().ToList();
                MessageBoxResult messageBoxResult = MessageBox.Show("Czy na pewno chcesz usunąć wybrane role?", "Potwierdź usunięcie", MessageBoxButton.YesNo);
                {
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        foreach (Role role in selectedRoles)
                        {
                            roleService.DeleteRole(role.Id);
                        }
                        gridRoles.ItemsSource = LoadData();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd usuwania: " + e);
            }
        }

        private IList<Role> SearchRoles()
        {
            List<string> criteria = new List<string>();
            criteria.Add(textBoxIdName.Text);                           //criteria[0] = Id/Name
            IList<Role> searchedRoles = roleService.SearchRoles(criteria);
            return searchedRoles;

        }
    }
}