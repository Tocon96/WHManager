using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IItemService
    {
        Task CreateNewItem(Item item);
        IList<Item> GetItems();
        Item GetItem(int id);
        Task UpdateItem(Item item);
        Task DeleteItem(int id);
        IList<Item> GetItemsByProduct(int? productId = null, string productName = null);
        IList<Item> GetEmittedItemsByProducts(int? productId = null, string productName = null);
        IList<Item> GetItemsByDate(DateTime? earlierDate, DateTime? laterDate);
        IList<Item> GetEmittedItemsByDate(DateTime? earlierDate, DateTime? laterDate);
    }
}
