using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.DataAccess.Repositories
{
	public class ItemRepository : IItemRepository
	{
		private readonly WHManagerDBContextFactory _contextFactory;

		public ItemRepository(WHManagerDBContextFactory contextFactory)
		{
			_contextFactory = contextFactory;
		}

		public int AddItem(int product, DateTime dateofadmission, DateTime? dateofemission, bool isinstock, int incomingDocumentId, int deliveryId, int providerId)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				try
				{
					Item newItem = new Item
					{
						DateOfAdmission = dateofadmission,
						DateOfEmission = dateofemission,
						Product = context.Products.SingleOrDefault(x => x.Id == product),
						IsInStock = isinstock,
						IsInOrder = false,
						IncomingDocument = context.IncomingDocuments.SingleOrDefault(x => x.Id == incomingDocumentId),
						DeliveryId = deliveryId,
						Provider = context.Provider.SingleOrDefault(x=>x.Id == providerId)
					};
                
					context.Items.Add(newItem);
					context.SaveChanges();
					return newItem.Id;
				}
                catch
                {
					throw new Exception("B³¹d dodawania przedmiotu: ");
                }
			}
		}
		
		public IEnumerable<Item> GetItems()
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					IEnumerable<Item> items = context.Items.Include(p => p.Product)
															.Include(i => i.IncomingDocument)
															.Include(p => p.Provider)
															.Include(o => o.OutgoingDocument)
															.Include(i => i.Invoice)
															.ToList();
					return items;
				}
                catch
                {
					throw new Exception("B³¹d pobierania przedmiotów: ");
				}
			}
		}
		public Item GetItem(int id)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					return context.Items.Include(p => p.Product).Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice).SingleOrDefault(x => x.Id == id);
				}
				catch
				{
					throw new Exception("B³¹d pobierania przedmiotu: ");
				}
			}
		}

		public void DeleteItem(int id)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					context.Items.Remove(context.Items.SingleOrDefault(x => x.Id == id));
					context.SaveChanges();
				}
				catch
				{
					throw new Exception("B³¹d usuwania przedmiotu: ");
				}
			}
		}
		public void UpdateItem(int id, int product, DateTime dateofadmission, DateTime? dateofemission, bool isinstock, int incomingDocumentId, int? outgoingDocumentId, int deliveryId, int providerId, int? orderId)
		{
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
                try
                {
					Item updatedItem = context.Items.SingleOrDefault(x => x.Id == id);
					updatedItem.Product = context.Products.SingleOrDefault(x => x.Id == product);
					updatedItem.DateOfAdmission = dateofadmission;
					updatedItem.DateOfEmission = dateofemission;
					updatedItem.IsInStock = isinstock;
					if(outgoingDocumentId != null)
                    {
						updatedItem.OutgoingDocument = context.OutgoingDocuments.SingleOrDefault(x => x.Id == outgoingDocumentId);

					}
					if(orderId != null)
                    {
						updatedItem.OrderId = (int)orderId;
                    }
					updatedItem.Provider = context.Provider.SingleOrDefault(x => x.Id == providerId);
					updatedItem.IncomingDocument = context.IncomingDocuments.SingleOrDefault(x => x.Id == incomingDocumentId);
					updatedItem.DeliveryId = deliveryId;
					context.SaveChanges();
				}
                catch
                {
					throw new Exception("B³¹d aktualizacji przedmiotu o ID "+ id + " : ");
                }
				
			}
		}

		public IEnumerable<Item> GetEmittedItemsByProducts(int? productId = null, string productName = null)
		{
			if (productId != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.ToList().FindAll(p => p.Product.Id == productId && p.IsInStock==false);
						return items;
					}
				}
				catch (Exception)
				{
					throw new Exception("B³¹d usuwania przedmiotów: ");
				}
			}
			else if (productName != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.ToList().FindAll(p => p.Product.Name.StartsWith(productName) && p.IsInStock == false);
						return items;
					}
				}
				catch (Exception)
				{
					throw new Exception("B³¹d usuwania przedmiotów: ");
				}
			}
			else
			{
				throw new Exception("B³¹d usuwania przedmiotów: ");
			}
		}
		public IEnumerable<Item> GetItemsByProducts(int? productId = null, string productName = null)
		{
			if (productId != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.ToList().FindAll(p => p.Product.Id == productId && p.IsInStock == true);
						return items;
					}
				}
				catch (Exception)
				{
					throw new Exception("B³¹d usuwania przedmiotów: ");
				}
			}
			else if (productName != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.ToList().FindAll(p => p.Product.Name.StartsWith(productName) && p.IsInStock == true);
						return items;
					}
				}
				catch
				{
					throw new Exception("B³¹d usuwania przedmiotów: ");
				}
			}
			else
			{
				throw new Exception("B³¹d usuwania przedmiotów: ");
			}
		}
		public IEnumerable<Item> GetItemsByDate(DateTime? earlierDate, DateTime? laterDate)
		{
			if (earlierDate != null && laterDate != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.ToList().FindAll(x => x.DateOfAdmission >= earlierDate && x.DateOfAdmission <= laterDate && x.IsInStock == true);
						return items;
					}
				}
				catch
				{
					throw new Exception("B³¹d usuwania przedmiotów: "); ;
				}
			}
			else if (earlierDate != null && laterDate == null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.ToList().FindAll(x => x.DateOfAdmission >= earlierDate && x.IsInStock == true);
						return items;
					}
				}
				catch
				{
					throw new Exception("B³¹d usuwania przedmiotów: "); ;
				}
			}
			else if (earlierDate == null && laterDate != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.ToList().FindAll(x => x.DateOfAdmission <= laterDate && x.IsInStock == true);
						return items;
					}
				}
				catch
				{
					throw new Exception("B³¹d usuwania przedmiotów: "); ;
				}
			}
			else if (earlierDate == null && laterDate == null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.Include(p => p.Provider).ToList();
						return items;
					}
				}
				catch 
				{
					throw new Exception("B³¹d usuwania przedmiotów: ");
				}
			}
			else
			{
				throw new Exception("B³¹d usuwania przedmiotów: ");
			}
		}
		public IEnumerable<Item> GetEmittedItemsByDate(DateTime? earlierDate, DateTime? laterDate)
		{
			if (earlierDate != null && laterDate != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.ToList().FindAll(x => x.DateOfEmission >= earlierDate && x.DateOfEmission <= laterDate && x.IsInStock == false);
						return items;
					}
				}
				catch
				{
					throw new Exception("B³¹d usuwania przedmiotów: ");
				}
			}
			else if (earlierDate != null && laterDate == null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.ToList().FindAll(x => x.DateOfEmission >= earlierDate && x.IsInStock == false);
						return items;
					}
				}
				catch
				{
					throw new Exception("B³¹d usuwania przedmiotów: ");
				}
			}
			else if (earlierDate == null && laterDate != null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice)
																.ToList().FindAll(x => x.DateOfEmission <= laterDate && x.IsInStock == false);
						return items;
					}
				}
				catch
				{
					throw new Exception("B³¹d usuwania przedmiotów: ");
				}
			}
			else if (earlierDate == null && laterDate == null)
			{
				try
				{
					using (WHManagerDBContext context = _contextFactory.CreateDbContext())
					{
						IEnumerable<Item> items = context.Items.Include(p => p.Product)
																.Include(i => i.IncomingDocument)
																.Include(p => p.Provider)
																.Include(o => o.OutgoingDocument)
																.Include(i => i.Invoice).ToList();
						return items;
					}
				}
				catch
				{
					throw new Exception("B³¹d usuwania przedmiotów: ");
				}
			}
			else
			{
				throw new Exception("B³¹d usuwania przedmiotów: ");
			}
		}

        public IEnumerable<Item> GetAllAvailableItems()
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				IEnumerable<Item> items = context.Items.Include(p => p.Product).Include(o => o.OutgoingDocument)
															.Include(i => i.Invoice).Include(i => i.IncomingDocument).Include(p => p.Provider).ToList().FindAll(x => x.IsInStock == true && x.IsInOrder == false);
				return items;
			}
		}

		public void SetItemInOrder(int productId, int orderId)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Item updatedItem = context.Items.FirstOrDefault(x => x.Product.Id == productId && x.IsInOrder == false);
				updatedItem.IsInOrder = true;
				updatedItem.OrderId = orderId;
				context.SaveChanges();
			}
		}

		public void RemoveItemFromOrder(int id)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Item updatedItem = context.Items.SingleOrDefault(x => x.Id == id);
				updatedItem.IsInOrder = false;
				updatedItem.OrderId = null;
				context.SaveChanges();
			}
		}

		public void AddItemToOrder(int id, int orderId)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Item updatedItem = context.Items.FirstOrDefault(x => x.Id == id && x.IsInOrder == false);
				updatedItem.IsInOrder = true;
				updatedItem.OrderId = orderId;
				context.SaveChanges();
			}
		}

		public void EmitItem(int id, DateTime dateTime, int documentId, int invoiceId)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Item updatedItem = context.Items.SingleOrDefault(x => x.Id == id);
				updatedItem.IsInStock = false;
				updatedItem.DateOfEmission = dateTime;
				updatedItem.OutgoingDocument = context.OutgoingDocuments.SingleOrDefault(x => x.Id == documentId);
				updatedItem.Invoice = context.Invoices.SingleOrDefault(x => x.Id == invoiceId);
				context.SaveChanges();
			}
		}

        public bool CheckCountOfAvailableItems(int count)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				if(context.Items.Count(x=>x.IsInOrder == false) >= count)
                {
					return true;
                }else
                {
					return false;
                }
			}
		}

        public IEnumerable<Item> GetItemsByOrder(int orderId)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				IEnumerable<Item> items = context.Items.Include(p => p.Product).Include(o => o.OutgoingDocument)
															.Include(i => i.Invoice).Include(i => i.IncomingDocument).Include(p => p.Provider).ToList().FindAll(x=>x.OrderId == orderId);
				return items;
			}
		}

        public bool CheckCountOfAvailableItemsPerProduct(int count, int productId)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				if (context.Items.Count(x => x.IsInOrder == false && x.Product.Id == productId) >= count)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

        public void RemoveItemsFromOrderByProduct(int orderId, int productId)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Item updatedItem = context.Items.Include(p => p.Product).FirstOrDefault(x => x.Product.Id == productId && x.OrderId == orderId);
				updatedItem.IsInOrder = false;
				updatedItem.OrderId = null;
				context.SaveChanges();
			}
		}

        public void AddItemsToOrderByProduct(int orderId, int productId)
        {
			using (WHManagerDBContext context = _contextFactory.CreateDbContext())
			{
				Item updatedItem = context.Items.Include(p => p.Product).FirstOrDefault(x => x.Product.Id == productId && x.IsInOrder == false);
				updatedItem.IsInOrder = true;
				updatedItem.OrderId = orderId;
				context.SaveChanges();
			}
		}
    }
}