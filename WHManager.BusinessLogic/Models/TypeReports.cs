using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class TypeReports
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType Type { get; set; }
        public DateTime? DateRealizedFrom { get; set; }
        public DateTime? DateRealizedTo { get; set; }

    }
}
