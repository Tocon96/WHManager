using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.BusinessLogic.ViewModels
{
    public class TaxViewModel : MvxViewModel
    {
        private ObservableCollection<Tax> _taxes;

        public ObservableCollection<Tax> Taxes
        {
            get { return _taxes; }
            set { _taxes = value; }
        }

        public TaxViewModel()
        {
            LoadData();
        }

        private List<Tax> GetAll()
        {
            ITaxService taxService = new TaxService();
            List<Tax> taxes = taxService.GetTaxes();
            return taxes;
        }
        private ObservableCollection<Tax> LoadData()
        {
            List<Tax> taxesList = GetAll();
            Taxes = new ObservableCollection<Tax>(taxesList);
            return Taxes;
        }
    }
}