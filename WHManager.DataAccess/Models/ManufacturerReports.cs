using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class ManufacturerReports
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public DateTime? DateRealizedFrom { get; set; }
        public DateTime? DateRealizedTo { get; set; }
    }
}
