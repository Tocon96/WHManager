using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class DocumentData
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public DateTime DocumentDate { get; set; }
        public string DocumentType { get; set; }
        public string ContrahentName { get; set; }
        public string ContrahentNip { get; set; }
        public string ContrahentPhoneNumber { get; set; }
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public int TaxType { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TaxValue { get; set; }
        public decimal GrossValue { get; set; }
        public decimal NetValue {get; set;}
    }
}
