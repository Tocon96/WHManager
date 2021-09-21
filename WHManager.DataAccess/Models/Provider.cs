using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Nip { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<IncomingDocument> IncomingDocuments { get; set; }
    }
}
