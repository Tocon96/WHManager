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
using System.Windows.Shapes;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.DesktopUI.Views.FormViews
{
    /// <summary>
    /// Interaction logic for ManageCompanyDataFormView.xaml
    /// </summary>
    public partial class ManageCompanyDataFormView : Window
    {
        private IList<Config> Data { get; set; }
        public ManageCompanyDataFormView(IList<Config>data)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Data = data;

            textBoxCompanyName.Text = Data[0].Value;
            textBoxCompanyPhoneNumber.Text = Data[1].Value;
            textBoxCompanyNip.Text = Data[2].Value;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void buttonConfirmClick(object sender, RoutedEventArgs e)
        {
            IConfigService configService = new ConfigService();
            IList<string> data = new List<string>();
            data.Add(textBoxCompanyName.Text);
            data.Add(textBoxCompanyPhoneNumber.Text);
            data.Add(textBoxCompanyNip.Text);
            if(data.Any(x => x.Length == 0))
            {
                MessageBox.Show("Wartości nie mogą być puste");
            }
            else
            {
                configService.UpdateCompanyData(data.ToList());
                DialogResult = true;
                this.Close();
            }
            
        }
    }
}
