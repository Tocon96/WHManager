using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class ProductReports
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }
        public DateTime? DateRealizedFrom { get; set; }
        public DateTime? DateRealizedTo { get; set; }
    }
}
