using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Nip { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}