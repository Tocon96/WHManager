using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public Provider Provider { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateRealized { get; set; }
        public bool Realized { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}