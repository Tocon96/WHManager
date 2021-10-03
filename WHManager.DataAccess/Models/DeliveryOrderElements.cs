using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class DeliveryOrderElements
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public int DeliveryId { get; set; }
    }
}
