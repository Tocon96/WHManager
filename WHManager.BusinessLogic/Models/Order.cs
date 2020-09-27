using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IList<Item> Items { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOrdered { get; set; }
        public Invoice Invoice { get; set; }
        public bool IsRealized { get; set; }
        public Client Client { get; set; }
    }
}
