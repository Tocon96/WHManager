using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Nip { get; set; }
        public string PhoneNumber { get; set; }
        public IList<Item> Items { get; set; }
        public IList<IncomingDocument> IncomingDocuments { get; set; }
    }
}
