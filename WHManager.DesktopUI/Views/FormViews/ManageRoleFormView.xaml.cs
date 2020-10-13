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

        public ManageRoleFormView()
        {
            InitializeComponent();
        }
        public ManageRoleFormView(Role role)
        {
            InitializeComponent();
            Role = role;
            labelId.Visibility = Visibility.Visible;
            labelId.Content = Role.Id;
        }

        private void ButtonAddRoleClick(object sender, RoutedEventArgs e)
        {
            if(labelId.Visibility != Visibility.Visible)
            {
                AddRole();
                this.Close();
            }
            else if(labelId.Visibility == Visibility.Visible)
            {
                UpdateRole();
                this.Close();
            }
        }
        private void AddRole()
        {
            try
            {
                IRoleService roleService = new RoleService();
                Role role = new Role
                {
                    Name = textBoxName.Text
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
                    Name = textBoxName.Text
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
