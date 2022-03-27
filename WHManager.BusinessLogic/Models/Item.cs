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
        public bool IsInOrder { get; set; }
        public int? OrderId { get; set; }
        public int ProviderId { get; set; }
        public int IncomingDocumentId { get; set; }
        public int? OutgoingDocumentId { get; set; }
        public int? InvoiceId { get; set; }
        public int DeliveryId { get; set; }
    }
}
