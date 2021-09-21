using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class OutgoingDocument
    {
        public int Id { get; set; }
        public bool Source { get; set; }
        public Client Contrahent { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime DateReceived { get; set; }
        public Order Order { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<Item> Items { get; set; }

    }
}
