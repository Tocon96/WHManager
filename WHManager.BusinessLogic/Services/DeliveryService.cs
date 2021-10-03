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
        IDeliveryOrderElementsRepository elementRepository = new DeliveryOrderElementsRepository(new DataAccess.WHManagerDBContextFactory());
        IProductService productService = new ProductService();
        IProviderService providerService = new ProviderService();
        IIncomingDocumentService documentService = new IncomingDocumentService();
        public int AddDelivery(Delivery delivery, List<DeliveryOrderTableContent> elements)
        {
            int deliveryId = deliveryRepository.AddDelivery(delivery.Provider.Id, delivery.DateCreated);
            foreach (DeliveryOrderTableContent element in elements)
            {
                elementRepository.CreateElement("Delivery", element.ProductId, (int)element.Count, deliveryId);
            }
            return deliveryId;
        }

        public void RealizeDelivery(Delivery delivery)
        {
            DateTime currentDate = DateTime.Now;
            IncomingDocument document = new IncomingDocument
            {
                DateReceived = currentDate,
                DeliveryId = delivery.Id,
                Provider = providerService.GetProvider(delivery.Provider.Id)
            };
            int documentId = documentService.AddDocument(document);
            var content = elementRepository.GetElementsByDeliveryId("Delivery", delivery.Id);
            foreach (var element in content)
            {
                IList<Item> items = new List<Item>();
                for (int i = 0; i < element.ProductCount; i++)
                {
                    Item item = new Item
                    {
                        Product = productService.GetProduct(element.ProductId)[0],
                        DateOfAdmission = delivery.DateCreated,
                        DateOfEmission = null,
                        Provider = providerService.GetProvider(delivery.Provider.Id),
                        DeliveryId = delivery.Id,
                        IncomingDocument = documentService.GetDocument(documentId),
                        IsInStock = true
                    };
                    items.Add(item);
                }
                itemService.CreateNewItems(items.ToList());
            }
            deliveryRepository.UpdateDelivery(delivery.Id, delivery.Provider.Id, delivery.DateCreated, currentDate, true);
        }
        public void DeleteDelivery(int id)
        {
            deliveryRepository.DeleteDelivery(id);
            elementRepository.DeleteElementsByDeliveryId("Delivery", id);
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
                    DateCreated = delivery.DateCreated,
                    DateRealized = delivery.DateRealized,
                    Items = itemsList,
                    Provider = provider,
                    Realized = delivery.Realized
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
                DateCreated = delivery.DateCreated,
                Items = itemsList,
                Provider = provider
            };
            return newDelivery;
        }

        public IList<Delivery> SearchDeliveries(IList<string> criteria)
        {
            IList<Delivery> deliveriesList = new List<Delivery>();
            var deliveries = deliveryRepository.SearchDeliveries(criteria);
            foreach (var delivery in deliveries)
            {
                IList<Item> itemsList = new List<Item>();
                foreach (var item in delivery.Items)
                {
                    itemsList.Add(itemService.GetItem(item.Id));
                }
                Delivery newDelivery = new Delivery
                {
                    Id = delivery.Id,
                    DateCreated = delivery.DateCreated,
                    Items = itemsList,
                    Provider = providerService.GetProvider(delivery.Provider.Id)
                };
                deliveriesList.Add(newDelivery);
            }
            return deliveriesList;
        }

        public int UpdateDelivery(Delivery delivery, List<DeliveryOrderTableContent> elements)
        {
            var existingElements = elementRepository.GetElementsByDeliveryId("Delivery", delivery.Id).ToList();
            IList<DeliveryOrderTableContent> existingContent = new List<DeliveryOrderTableContent>();
            foreach(var element in existingElements)
            {
                DeliveryOrderTableContent content = new DeliveryOrderTableContent(element.Id, element.ProductId, "", (int)element.ProductCount);
                existingContent.Add(content);
            }

            foreach(DeliveryOrderTableContent element in elements)
            {
                if(existingContent.Any(x => x.ProductId == element.ProductId))
                {
                    DeliveryOrderTableContent content = existingContent.SingleOrDefault(x => x.ProductId == element.ProductId);
                    if (content.Count != element.Count)
                    {
                        content.Count = element.Count;
                        elementRepository.UpdateElement((int)content.Id, "Delivery", content.ProductId, (int)element.Count, null);
                    }
                }
                else
                {
                    elementRepository.CreateElement("Delivery", element.ProductId, (int)element.Count, delivery.Id);
                }
            }

            foreach(DeliveryOrderTableContent content in existingContent)
            {
                if(elements.All(x=>x.ProductId != content.ProductId))
                {
                    elementRepository.DeleteElement((int)content.Id);
                }
            }

            return deliveryRepository.UpdateDelivery(delivery.Id, delivery.Provider.Id, delivery.DateCreated, delivery.DateRealized, delivery.Realized);
        }

        public IList<DeliveryOrderTableContent> GetElements(int deliveryId)
        {
            var contents = elementRepository.GetElementsByDeliveryId("Delivery", deliveryId);
            IList<DeliveryOrderTableContent> elements = new List<DeliveryOrderTableContent>();
            foreach(var content in contents) 
            {
                Product product = productService.GetProduct(content.ProductId)[0];
                DeliveryOrderTableContent element = new DeliveryOrderTableContent(null, content.ProductId, product.Name, (double)content.ProductCount);
                elements.Add(element);
            }
            return elements;
        }
    }
}
