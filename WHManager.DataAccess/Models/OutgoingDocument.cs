using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class OutgoingDocument
    {
        public int Id { get; set; }
        public Client Contrahent { get; set; }
        public DateTime DateSent { get; set; }
        public Order Order { get; set; }
        public Invoice Invoice { get; set; }
    }
}
