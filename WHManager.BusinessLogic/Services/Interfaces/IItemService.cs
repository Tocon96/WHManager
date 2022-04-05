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
        IList<Item> GetAllItemsByProduct(int productId);
        IList<Item> GetAllAvailableItems();
        IList<DeliveryOrderTableContent> GroupItems();
        void SetItemInOrder(Item item, int orderId, int count);
        void RemoveItemsFromOrderByProduct(int orderId, int productId);
        void RemoveItemsFromOrder(int orderId);
        void AddItemsToOrderByProduct(int orderId, int productId);
        bool CheckCountOfAvailableItems(int count);
        bool CheckCountOfAvailableItemsPerProduct(int count, int productId);
        void SetItemsToOrder(int orderId, List<DeliveryOrderTableContent> elements);
        void EmitItemsInOrder(int orderId, DateTime dateTime, int documentId, int invoiceId);
    }
}