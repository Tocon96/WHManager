﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.DataAccess.Repositories;
using WHManager.DataAccess.Repositories.Interfaces;

namespace WHManager.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository = new ProductRepository(new DataAccess.WHManagerDBContextFactory());

        public async Task CreateNewProduct(Product product)
        {
            try
            {
                int id = product.Id;
                string name = product.Name;
                int productType = product.Type.Id;
                int tax = product.Tax.Id;
                int manufacturer = product.Manufacturer.Id;
                await _productRepository.AddProductAsync(id, name, productType, tax, manufacturer);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IList<Product> GetProducts()
        {
            try
            {
                IList<Product> productsList = new List<Product>();
                var products = _productRepository.GetAllProducts();
                foreach (var product in products)
                {
                    Product currentProduct = new Product
                    {
                        Id = product.Id,
                        Name = product.Name,
                    };
                    currentProduct.Type.Id = product.Type.Id;
                    currentProduct.Tax.Id = product.Tax.Id;
                    currentProduct.Manufacturer.Id = product.Manufacturer.Id;
                    productsList.Add(currentProduct);
                }
                return productsList;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
		
		public async Task<Product> GetProduct(int id)
		{
            try
            {
                var product = await _productRepository.GetProductAsync(id);
                Product currentProduct = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                };
                currentProduct.Type.Id = product.Type.Id;
                currentProduct.Tax.Id = product.Tax.Id;
                currentProduct.Manufacturer.Id = product.Manufacturer.Id;

                return currentProduct;
            }
            catch(Exception e)
            {
                throw e;
            }
		}
		
		public async Task UpdateProduct(Product product)
		{
            try
            {
                int id = product.Id;
                string name = product.Name;
                int productType = product.Type.Id;
                int tax = product.Tax.Id;
                int manufacturer = product.Manufacturer.Id;
                await _productRepository.UpdateProductAsync(id, name, productType, tax, manufacturer);
            }
            catch(Exception e)
            {
                throw e;
            }
			
		}
		public async Task DeleteProduct(int id)
		{
            try 
            { 
                await _productRepository.DeleteProductAsync(id); 
            }
            catch (Exception e)
            {
                throw e;
            }
        }
		
    }
}   