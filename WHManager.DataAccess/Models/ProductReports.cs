using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class ProductReports
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ProductId { get; set; }
        public int? ManufacturerId { get; set; }
        public int? TypeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
