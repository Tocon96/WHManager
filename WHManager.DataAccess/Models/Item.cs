using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
		public DateTime DateOfAdmission {get; set;}
		public DateTime? DateOfEmission {get; set;}
        public bool IsInStock { get; set; }
        public bool IsInOrder { get; set; }
        [AllowNull]
        public int? OrderId { get; set; }
        public Provider Provider { get; set; }
        public IncomingDocument IncomingDocument { get; set; }
        public OutgoingDocument OutgoingDocument { get; set; }
        public Invoice Invoice { get; set; }
        public int DeliveryId { get; set; }
    }
}