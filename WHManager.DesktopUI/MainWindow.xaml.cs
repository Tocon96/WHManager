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
using WHManager.BusinessLogic.Services.CommandService;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DesktopUI.Views.FormViews.LoginForm;

namespace WHManager.DesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IRoleService roleService = new RoleService();
        public User User
        {
            get;
            set;
        }

        public List<MenuItemsData> MenuList
        {
            get
            {
                List<MenuItemsData> menu = new List<MenuItemsData>();
                Role role = roleService.GetRoleById(User.Role.Id)[0];
                if(role.Warehouse == true)
                {
                    MenuItemsData menuItem = new MenuItemsData()
                    {
                        MenuText = "Produkty",
                        SubMenuList = new List<SubMenuItemsData>{
                            new SubMenuItemsData(){ SubMenuDirectory="WarehouseViews", File = "ProductView", SubMenuText="Produkt" },
                            new SubMenuItemsData(){ SubMenuDirectory="WarehouseViews", File = "ProductTypeView", SubMenuText="Typ Produktów" },
                            new SubMenuItemsData(){ SubMenuDirectory="WarehouseViews", File = "TaxView", SubMenuText="Typ Podatków" }
                        }
                    };
                    menu.Add(menuItem);
                }
                if(role.Contractors == true)
                {
                    MenuItemsData menuItem = new MenuItemsData()
                    {
                        MenuText = "Kontrahenci",
                        SubMenuList = new List<SubMenuItemsData>{
                            new SubMenuItemsData(){ SubMenuDirectory="ContractorsViews", File = "ClientView", SubMenuText="Klienci" },
                            new SubMenuItemsData(){ SubMenuDirectory="ContractorsViews", File = "ManufacturerView", SubMenuText="Producenci" },
                            new SubMenuItemsData(){ SubMenuDirectory="ContractorsViews", File = "ProviderView", SubMenuText="Dostawcy" }
                        }
                    };
                    menu.Add(menuItem);
                }
                if(role.Business == true)
                {
                    MenuItemsData menuItem = new MenuItemsData()
                    {
                        MenuText = "Biznes",
                        SubMenuList = new List<SubMenuItemsData>{
                            new SubMenuItemsData(){ SubMenuDirectory="BusinessViews", File = "OrderView", SubMenuText="Zamówienia" },
                            new SubMenuItemsData(){ SubMenuDirectory="BusinessViews", File = "DeliveryView", SubMenuText="Dostawy"}
                        }
                    };
                    menu.Add(menuItem);
                }
                if(role.Documents == true)
                {
                    MenuItemsData menuItem = new MenuItemsData()
                    {
                        MenuText = "Dokumenty",
                        SubMenuList = new List<SubMenuItemsData>
                        {
                            new SubMenuItemsData() { SubMenuDirectory = "DocumentViews", File = "IncomingDocumentView", SubMenuText = "Dokumenty Przychodzące"},
                            new SubMenuItemsData() { SubMenuDirectory = "DocumentViews", File = "OutgoingDocumentView", SubMenuText = "Dokumenty Wychodzące"},
                            new SubMenuItemsData() { SubMenuDirectory = "DocumentViews", File = "InvoiceView", SubMenuText="Faktury" },
                        }
                    };
                    menu.Add(menuItem);
                }
                if (role.Admin == true)
                {
                    MenuItemsData menuItem = new MenuItemsData()
                    {
                        MenuText = "Panel Administracyjny",
                        SubMenuList = new List<SubMenuItemsData>{
                            new SubMenuItemsData(){ SubMenuDirectory="AdministrationViews", File = "RoleView", SubMenuText="Role" },
                            new SubMenuItemsData(){ SubMenuDirectory="AdministrationViews", File = "UserView", SubMenuText="Użytkownicy" }
                        }
                    };
                    menu.Add(menuItem);
                }
                return menu;
            }
        }

        public MainWindow(User user)
        {
            InitializeComponent();
            DataContext = this;
            User = user;
            labelName.Content = (user.UserName);
            mainContent.Navigate(new Uri(string.Format("{0}{1}{2}{3}", "Views/", "WarehouseViews/", "ProductView", ".xaml"), UriKind.RelativeOrAbsolute));

        }

        private void buttonLogout(object sender, RoutedEventArgs e)
        {
            LoginFormView loginFormView = new LoginFormView();
            loginFormView.Show();
            this.Close();
        }

        public class MenuItemsData
        {
            //Icon Data
            public string MenuText { get; set; }
            public List<SubMenuItemsData> SubMenuList { get; set; }

            public MenuItemsData()
            {

            }
        }

        public class SubMenuItemsData
        {
            public string SubMenuText { get; set; }

            public string SubMenuDirectory { get; set; }

            public string File { get; set; }

            //To Add click event to our Buttons we will use ICommand here to switch pages when specific button is clicked
            public SubMenuItemsData()
            {
                SubMenuCommand = new CommandService(Execute);
            }

            public ICommand SubMenuCommand { get; }

            private void Execute()
            {
                if (!string.IsNullOrEmpty(SubMenuDirectory) && !string.IsNullOrEmpty(File))
                    navigateToPage(SubMenuDirectory, File);
            }

            private void navigateToPage(string Directory, string Menu)
            {
                //We will search for our Main Window in open windows and then will access the frame inside it to set the navigation to desired page..
                //lets see how... ;)
                foreach (System.Windows.Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).mainContent.Navigate(new Uri(string.Format("{0}{1}{2}{3}", "Views/", Directory + "/", Menu, ".xaml"), UriKind.RelativeOrAbsolute));
                    }
                }
            }
        }
    }
}
