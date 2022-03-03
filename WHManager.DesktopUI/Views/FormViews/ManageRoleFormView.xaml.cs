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
            CheckBoxes();
        }

        private void CheckBoxes()
        {
            textBoxName.Text = Role.Name;
            checkboxAdmin.IsChecked = Role.Admin;
            checkboxWarehouse.IsChecked = Role.Warehouse;
            checkboxBusiness.IsChecked = Role.Business;
            checkboxContractors.IsChecked = Role.Contractors;
            checkboxDocuments.IsChecked = Role.Documents;
            checkboxReports.IsChecked = Role.Report;
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
                IRoleService roleService = new RoleService();
                Role role = new Role
                {
                    Name = textBoxName.Text,
                    Admin = checkboxAdmin.IsChecked.Value,
                    Warehouse = checkboxWarehouse.IsChecked.Value,
                    Business = checkboxBusiness.IsChecked.Value,
                    Contractors = checkboxContractors.IsChecked.Value,
                    Documents = checkboxDocuments.IsChecked.Value,
                    Report = checkboxReports.IsChecked.Value
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
                IRoleService roleService = new RoleService();
                Role role = new Role
                {
                    Id = Role.Id,
                    Name = textBoxName.Text,
                    Admin = checkboxAdmin.IsChecked.Value,
                    Warehouse = checkboxWarehouse.IsChecked.Value,
                    Business = checkboxBusiness.IsChecked.Value,
                    Contractors = checkboxContractors.IsChecked.Value,
                    Documents = checkboxDocuments.IsChecked.Value,
                    Report = checkboxReports.IsChecked.Value
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
