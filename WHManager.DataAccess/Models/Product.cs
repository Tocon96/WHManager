using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public Tax Tax { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public decimal PriceBuy { get; set; }
        public decimal PriceSell { get; set; }
        public bool InStock { get; set; }
    }
}
