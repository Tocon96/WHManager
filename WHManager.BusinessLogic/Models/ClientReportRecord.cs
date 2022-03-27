using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class ClientReportRecord
    {
        public int OrderId { get; set; }
        public int ItemCount { get; set; }
        public decimal PriceNet { get; set; }
        public decimal PriceGross { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateRealized { get; set; }

    }
}
