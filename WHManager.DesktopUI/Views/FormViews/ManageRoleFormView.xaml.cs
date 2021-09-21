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
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DesktopUI.Views.AdministrationViews;

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for ManageRoleFormView.xaml
    /// </summary>
    public partial class ManageRoleFormView : Window
    {
        public Role Role
        {
            get;
            set;
        }

        private RoleView RoleGridView
        {
            get;
            set;
        }

        public ManageRoleFormView(RoleView roleView)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            RoleGridView = roleView;
        }
        public ManageRoleFormView(RoleView roleView, Role role)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Role = role;
            RoleGridView = roleView;
            textBoxName.Text = role.Name;
            if(role.Admin == true)
            {
                checkboxAdmin.IsChecked = true;
            }
        }

        private void ButtonAddRoleClick(object sender, RoutedEventArgs e)
        {
            if(Role != null)
            {
                UpdateRole();
                DialogResult = true;
                this.Close();
            }
            else
            {
                AddRole();
                DialogResult = true;
                this.Close();
            }
        }

        private void ButtonCancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }


        public void OnDialogClose()
        {
            RoleGridView.gridRoles.Items.Refresh();
        }

        private void textBoxName_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBoxName.Clear();
        }

        private void AddRole()
        {
            try
            {
                bool admin = false;
                if(checkboxAdmin.IsChecked == true)
                {
                    admin = true;
                }
                IRoleService roleService = new RoleService();
                Role role = new Role
                {
                    Name = textBoxName.Text,
                    Admin = admin
                };
                roleService.AddRole(role);
            }
            catch (Exception e)
            {
                MessageBox.Show("Błąd dodawania: " + e);
            }
        }
        private void UpdateRole()
        {
            try
            {
                bool admin = false;
                if (checkboxAdmin.IsChecked == true)
                {
                    admin = true;
                }
                IRoleService roleService = new RoleService();
                Role role = new Role
                {
                    Id = Role.Id,
                    Name = textBoxName.Text,
                    Admin = admin
                };
                roleService.UpdateRole(role);
            }
            catch(Exception e)
            {
                MessageBox.Show("Błąd edycji: " + e);
            }
        }
    }
}
