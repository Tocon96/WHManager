using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IItemRepository
    {
        int AddItem(int product, DateTime dateofadmission, DateTime? dateofemission, bool isinstock, int incomingDocumentId, int deliveryId, int providerId);
        IEnumerable<Item> GetItems();
        Item GetItem(int id);
        void DeleteItem(int id);
        void UpdateItem(int id, int product, DateTime dateofadmission, DateTime? dateofemission, bool isinstock, int incomingDocumentId, int? outgoingDocumentId, int deliveryId, int providerId, int? orderId);
        IEnumerable<Item> GetItemsByProducts(int? productId = null, string productName = null);
        IEnumerable<Item> GetItemsByDate(DateTime? earlierDate, DateTime? laterDate);
        IEnumerable<Item> GetEmittedItemsByDate(DateTime? earlierDate, DateTime? laterDate);
        IEnumerable<Item> GetEmittedItemsByProducts(int? productId = null, string productName = null);
        IEnumerable<Item> GetAllAvailableItems();
        IEnumerable<Item> GetItemsByOrder(int orderId);
		void SetItemInOrder(int productId, int orderId);
        void AddItemToOrder(int id, int orderId);
		void RemoveItemFromOrder(int id);
        void EmitItem(int id, DateTime dateTime, int documentId, int invoiceId);
        bool CheckCountOfAvailableItems(int count);
        bool CheckCountOfAvailableItemsPerProduct(int count, int productId);
        void RemoveItemsFromOrderByProduct(int orderId, int productId);
        void AddItemsToOrderByProduct(int orderId, int productId);
    }
}