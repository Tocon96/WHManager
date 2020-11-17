﻿using System;
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
using WHManager.DesktopUI.WindowSetting.Interfaces;
using WHManager.DesktopUI.WindowSetting;

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
        private readonly IDisplaySetting displaySetting = new DisplaySetting();
        public ManageRoleFormView()
        {
            InitializeComponent();
            displaySetting.CenterWindowOnScreen(this);
        }
        public ManageRoleFormView(Role role)
        {
            InitializeComponent();
            displaySetting.CenterWindowOnScreen(this);
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
                bool admin = false;
                if(checkboxAdmin.IsChecked == true)
                {
                    admin = true;
                }
                IRoleService roleService = new RoleService();
                Role role = new Role
                {
                    Name = textBoxName.Text,
                    IsAdmin = admin
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
                    IsAdmin = admin
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
