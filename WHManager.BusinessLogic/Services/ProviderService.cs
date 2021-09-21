using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class ProviderService : IProviderService
    {
        private IProviderRepository providerRepository = new ProviderRepository(new DataAccess.WHManagerDBContextFactory());
        private IIncomingDocumentService incomingDocumentService = new IncomingDocumentService();
        private IItemService itemService = new ItemService();
        public int CreateProvider(Provider provider)
        {
            return providerRepository.AddProvider(provider.Name, provider.Nip, provider.PhoneNumber);
        }

        public void DeleteProvider(int id)
        {
            providerRepository.DeleteProvider(id);
        }

        public IList<Provider> GetAllProviders()
        {
            var providerEnumerable = providerRepository.GetAllProviders();
            IList<Provider> providerList = new List<Provider>();
            foreach(var provider in providerEnumerable)
            {
                IList<Item> itemsList = new List<Item>();
                IList<IncomingDocument> documentList = new List<IncomingDocument>();
                foreach (var item in provider.Items)
                {
                    itemsList.Add(itemService.GetItem(item.Id));
                }
                
                foreach (var incomingDocument in provider.IncomingDocuments)
                {
                    documentList.Add(incomingDocumentService.GetDocument(incomingDocument.Id));
                }
                Provider newProvider = new Provider
                {
                    Id = provider.Id,
                    Name = provider.Name,
                    Nip = provider.Nip,
                    PhoneNumber = provider.PhoneNumber,
                    Items = itemsList,
                    IncomingDocuments = documentList
                };
                providerList.Add(newProvider);
            }
            return providerList;
        }

        public Provider GetProvider(int id)
        {
            var provider = providerRepository.GetProviderById(id);
            IList<Item> itemsList = new List<Item>();
            IList<IncomingDocument> documentList = new List<IncomingDocument>();
            foreach (var item in provider.Items)
            {
                itemsList.Add(itemService.GetItem(item.Id));
            }

            foreach (var incomingDocument in provider.IncomingDocuments)
            {
                documentList.Add(incomingDocumentService.GetDocument(incomingDocument.Id));
            }
            Provider newProvider = new Provider
            {
                Id = provider.Id,
                Name = provider.Name,
                Nip = provider.Nip,
                PhoneNumber = provider.PhoneNumber,
                Items = itemsList,
                IncomingDocuments = documentList
            };
            return newProvider;
        }

        public IList<Provider> SearchProviders(List<string> criteria)
        {
            IList<Provider> providers = new List<Provider>();
            var providersList = providerRepository.SearchProviders(criteria);
            foreach (var provider in providersList)
            {
                Provider currentProvider = new Provider
                {
                    Id = provider.Id,
                    Name = provider.Name,
                    Nip = provider.Nip,
                    PhoneNumber = provider.PhoneNumber,
                };
                providers.Add(currentProvider);
            }
            return providers;

        }

        public int UpdateProvider(Provider provider)
        {
            return providerRepository.UpdateProvider(provider.Id, provider.Name, provider.Nip, provider.PhoneNumber);

        }
    }
}
