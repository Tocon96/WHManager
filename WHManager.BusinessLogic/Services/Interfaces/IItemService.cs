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
        List<Item> GetItems();
        Task<Item> GetItem(int id);
        Task UpdateItem(Item item);
        Task DeleteItem(int id);
    }
}
