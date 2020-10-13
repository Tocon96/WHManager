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
    /// Interaction logic for RoleView.xaml
    /// </summary>
    public partial class RoleView : UserControl
    {
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
            if (radiobuttonId.IsChecked == true)
            {
                try
                {
                    gridRoles.ItemsSource = LoadRolesById(int.Parse(textboxSearchRole.Text));
                }
                catch(Exception x)
                {
                    MessageBox.Show("Błąd wyszukiwania: " + x);
                }
            }
            else if(radiobuttonName.IsChecked == true)
            {
                try
                {
                    gridRoles.ItemsSource = LoadRolesByName(textboxSearchRole.Text);
                }
                catch (Exception x)
                {
                    MessageBox.Show("Błąd wyszukiwania: " + x);
                }
            }    
        }
        private void buttonClearSearchRoleClick(object sender, RoutedEventArgs e)
        {
            try
            {
                textboxSearchRole.Text = null;
                gridRoles.ItemsSource = LoadData();
            }
            catch(Exception x)
            {
                MessageBox.Show("Błąd czysczenia: " + x);
            }
        }
        private void buttonAddRoleClick(object sender, RoutedEventArgs e)
        {
            ManageRoleFormView roleFormView = new ManageRoleFormView();
            roleFormView.Show();
        }
        private void buttonUpdateRoleClick(object sender, RoutedEventArgs e)
        {
            if (gridRoles.SelectedItem != null)
            {
                Role role = gridRoles.SelectedItem as Role;
                ManageRoleFormView roleFormView = new ManageRoleFormView(role);
                roleFormView.Show();
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
                IRoleService roleService = new RoleService();
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
                    IRoleService roleService = new RoleService();
                    roleService.DeleteRole(role.Id);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Błąd usuwania:" + e);
                }
            }
        }
    }
}