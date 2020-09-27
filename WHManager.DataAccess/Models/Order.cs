using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ICollection<Item> Items { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOrdered { get; set; }
        public Invoice Invoice { get; set; }
        public bool IsRealized { get; set; }
        public Client Client { get; set; }
    }
}