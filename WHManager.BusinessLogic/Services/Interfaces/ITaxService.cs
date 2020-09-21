﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface ITaxService
    {
        Task CreateNewTax(Tax tax);
        IList<Tax> GetTaxes();
        Tax GetTax(int id);
        Task DeleteTax(int id);
        Task UpdateTax(Tax tax);
        IList<Tax> GetTaxesByName(string name);
        IList<Tax> GetTaxesByValue(int value);
    }
}
