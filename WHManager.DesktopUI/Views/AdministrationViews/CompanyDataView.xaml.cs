using System;
using System.Collections.Generic;
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
    /// Interaction logic for CompanyDataView.xaml
    /// </summary>
    public partial class CompanyDataView : UserControl
    {
        private IList<Config> Data { get; set; }
        public CompanyDataView()
        {
            InitializeComponent();
            GetCompanyData();
        }

        private void buttonEditDataClick(object sender, RoutedEventArgs e)
        {
            ManageCompanyDataFormView formView = new ManageCompanyDataFormView(Data);
            formView.ShowDialog();

            if(formView.DialogResult.Value == true)
            {
                 GetCompanyData();
            }
        }

        private void GetCompanyData()
        {
            IConfigService configService = new ConfigService();
            IList<Config> data = configService.GetCompanyData();

            Data = data;

            textBlockCompanyName.Text = data[0].Value;
            textBlockCompanyNumber.Text = data[1].Value;
            textBlockCompanyNip.Text = data[2].Value;
        }
    }
}
