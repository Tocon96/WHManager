using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IItemService
    {
        IList<int> CreateNewItems(List<Item> items);
        IList<Item> GetItems();
        Item GetItem(int id);
        void UpdateItem(Item item);
        void DeleteItem(int id);
        IList<Item> GetItemsByProduct(int? productId = null, string productName = null);
        IList<Item> GetEmittedItemsByProducts(int? productId = null, string productName = null);
    }
}