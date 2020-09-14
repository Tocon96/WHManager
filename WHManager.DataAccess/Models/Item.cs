using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
		public DateTime DateOfPurchase {get; set;}
		public DateTime DateOfSale {get; set;}
    }
}