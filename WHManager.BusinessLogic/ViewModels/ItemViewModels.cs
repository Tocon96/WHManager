using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services;
using WHManager.BusinessLogic.Services.Interfaces;

namespace WHManager.BusinessLogic.ViewModels
{
    public class ItemViewModel
    {
        private ObservableCollection<Item> _items;

        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        public ItemViewModel()
        {
            LoadData();
        }

        private List<Item> GetAll()
        {
            IItemService itemService = new ItemService();
            List<Item> items = itemService.GetItems();
            return items;
        }

        private ObservableCollection<Item> LoadData()
        {
            List<Item> itemsList = GetAll();
            Items = new ObservableCollection<Item>(itemsList);
            return Items;
        }
    }
}