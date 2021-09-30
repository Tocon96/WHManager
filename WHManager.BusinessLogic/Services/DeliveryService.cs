using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class DeliveryService : IDeliveryService
    {
        IDeliveryRepository deliveryRepository = new DeliveryRepository(new DataAccess.WHManagerDBContextFactory());
        IItemService itemService = new ItemService();
        IProductService productService = new ProductService();
        IProviderService providerService = new ProviderService();
        IIncomingDocumentService documentService = new IncomingDocumentService();
        public int AddDelivery(Delivery delivery, List<DeliveryOrderTableContent> elements)
        {
            IList<int> itemsIds = new List<int>();
            int deliveryId = deliveryRepository.AddDelivery(delivery.Provider.Id, delivery.DateOfArrival);
            IncomingDocument document = new IncomingDocument
            {
                DateReceived = delivery.DateOfArrival,
                DeliveryId = deliveryId,
                Provider = providerService.GetProvider(delivery.Provider.Id)
            };
            int documentId = documentService.AddDocument(document); 
            foreach (DeliveryOrderTableContent element in elements)
            {
                IList<Item> items = new List<Item>();
                IList<int> tempIds = new List<int>();

                for(int i = 0; i<element.Count; i++)
                {
                    Item item = new Item
                    {
                        Product = productService.GetProduct(element.Id)[0],
                        DateOfAdmission = delivery.DateOfArrival,
                        DateOfEmission = null,
                        Provider = providerService.GetProvider(delivery.Provider.Id),
                        DeliveryId = deliveryId,
                        IncomingDocument = documentService.GetDocument(documentId),
                        IsInStock = true
                    };
                    items.Add(item);
                }
                tempIds = itemService.CreateNewItems(items.ToList());
                foreach(int tempId in tempIds)
                {
                    itemsIds.Add(tempId);
                }
            }
            deliveryRepository.UpdateDelivery(deliveryId, delivery.Provider.Id, delivery.DateOfArrival, itemsIds);

            return deliveryId;
        }

        public void DeleteDelivery(int id)
        {
            deliveryRepository.DeleteDelivery(id);
        }

        public IList<Delivery> GetDeliveries()
        {
            var deliveries = deliveryRepository.GetAllDeliveries();
            IList<Delivery> deliveryList = new List<Delivery>();
            foreach(var delivery in deliveries)
            {
                IList<Item> itemsList = new List<Item>();
                foreach (var item in delivery.Items)
                {
                    itemsList.Add(itemService.GetItem(item.Id));
                }
                Provider provider = providerService.GetProvider(delivery.Provider.Id);
                Delivery newDelivery = new Delivery
                {
                    Id = delivery.Id,
                    DateOfArrival = delivery.DateOfArrival,
                    Items = itemsList,
                    Provider = provider
                };
                deliveryList.Add(newDelivery);
            }
            return deliveryList;
        }

        public Delivery GetDelivery(int id)
        {
            var delivery = deliveryRepository.GetDelivery(id);
            IList<Item> itemsList = new List<Item>();
            foreach (var item in delivery.Items)
            {
                itemsList.Add(itemService.GetItem(item.Id));
            }
            Provider provider = providerService.GetProvider(delivery.Provider.Id);
            Delivery newDelivery = new Delivery
            {
                Id = delivery.Id,
                DateOfArrival = delivery.DateOfArrival,
                Items = itemsList,
                Provider = provider
            };
            return newDelivery;
        }

        public IList<Delivery> SearchDeliveries(IList<string> criteria)
        {
            throw new NotImplementedException();
        }

        public int UpdateDelivery(Delivery delivery, List<DeliveryOrderTableContent> elements)
        {
            IList<int> items = new List<int>();
            foreach (Item item in delivery.Items)
            {
                items.Add(item.Id);
            }
            return deliveryRepository.UpdateDelivery(delivery.Id, delivery.Provider.Id, delivery.DateOfArrival, items);
        }
    }
}
