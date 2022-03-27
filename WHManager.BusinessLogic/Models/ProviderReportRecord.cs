using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class ProviderReportRecord
    {
        public int DeliveryId { get; set; }
        public int ItemCount { get; set; }
        public decimal PriceNet { get; set; }
        public decimal PriceGross { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateRealized { get; set; }
    }
}
