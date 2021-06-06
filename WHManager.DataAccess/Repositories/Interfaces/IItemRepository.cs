using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IItemRepository
    {
        int AddItem(int id, int product, DateTime dateofadmission, DateTime? dateofemission, bool isinstock);
        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        void DeleteItem(int id);
        void UpdateItem(int id, int product, DateTime dateofadmission, DateTime? dateofemission, bool isinstock);
        IEnumerable<Item> GetItemsByProducts(int? productId = null, string productName = null);
        IEnumerable<Item> GetItemsByDate(DateTime? earlierDate, DateTime? laterDate);
        IEnumerable<Item> GetEmittedItemsByDate(DateTime? earlierDate, DateTime? laterDate);
        IEnumerable<Item> GetEmittedItemsByProducts(int? productId = null, string productName = null);
    }
}
