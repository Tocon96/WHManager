using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public DateTime? DateOfEmission { get; set; }
        public bool IsInStock { get; set; }
        public Order Order { get; set; }
        public Provider Provider { get; set; }
        public IncomingDocument IncomingDocument { get; set; }
        public OutgoingDocument OutgoingDocument { get; set; }
        public int DeliveryId { get; set; }
    }
}
