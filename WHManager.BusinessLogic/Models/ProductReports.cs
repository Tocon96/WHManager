using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class ProductReports
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProductId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? TypeId { get; set; }
        public DateTime? DateDeliveredFrom { get; set; }
        public DateTime? DateDeliveredTo { get; set; }
        public DateTime? DateOrderedFrom { get; set; }
        public DateTime? DateOrderedTo { get; set; }

    }
}
