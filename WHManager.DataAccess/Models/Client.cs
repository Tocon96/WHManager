using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double? Nip { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OutgoingDocument> OutgoingDocuments { get; set; }
    }
}
