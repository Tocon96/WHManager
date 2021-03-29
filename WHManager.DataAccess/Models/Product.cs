using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public ProductType Type { get; set; }
        [Required]
        public Tax Tax { get; set; }
        [Required]
        public Manufacturer Manufacturer { get; set; }
        [Required]
        public decimal PriceBuy { get; set; }
        [Required]
        public decimal PriceSell { get; set; }
        [Required]
        public bool InStock { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
