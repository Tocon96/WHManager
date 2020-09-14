using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public Tax Tax { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public double PriceBuy { get; set; }
        public double PriceSell { get; set; }
        public bool InStock { get; set; }
    }
}
