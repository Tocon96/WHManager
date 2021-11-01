using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ICollection<Item> Items { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime? DateRealized { get; set; }
        [AllowNull]
        public Invoice Invoice { get; set; }
        [AllowNull]
        public bool IsRealized { get; set; }
        public Client Client { get; set; }
        public OutgoingDocument OutgoingDocument { get; set;}
        public IncomingDocument IncomingDocument { get; set; }
    }
}