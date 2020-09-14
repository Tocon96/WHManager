using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> AddItemAsync(int id, int product, DateTime dateofpurchase, DateTime dateofsale);
        IEnumerable<Item> GetItems();
        Task<Item> GetItemAsync(int id);
        Task DeleteItemAsync(int id);
        Task UpdateItemAsync(int id, int product, DateTime dateofpurchase, DateTime dateofsale);
    }
}
