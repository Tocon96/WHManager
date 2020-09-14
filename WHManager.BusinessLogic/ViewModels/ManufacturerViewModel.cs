using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.BusinessLogic.ViewModels
{
    public class ManufacturerViewModel
    {
        private ObservableCollection<Manufacturer> _manufacturers;

        public ObservableCollection<Manufacturer> Manufacturers
        {
            get { return _manufacturers; }
            set { _manufacturers = value; }
        }

        public ManufacturerViewModel()
        {
            LoadData();
        }

        private List<Manufacturer> GetAll()
        {
            IManufacturerService manufacturerService = new ManufacturerService();
            List<Manufacturer> manufacturers = manufacturerService.GetManufacturers();
            return manufacturers;
        }

        private ObservableCollection<Manufacturer> LoadData()
        {
            List<Manufacturer> manufacturersList = GetAll();
            Manufacturers = new ObservableCollection<Manufacturer>(manufacturersList);
            return Manufacturers;
        }
    }
}