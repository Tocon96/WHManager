﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<ProductType> AddProductTypeAsync(int id, string name);
        IEnumerable<ProductType> GetAllProductTypes();
        Task<ProductType> GetProductTypeAsync(int id);
        Task DeleteProductTypeAsync(int id);
        Task UpdateProductTypeAsync(int id, string name);

    }
}
