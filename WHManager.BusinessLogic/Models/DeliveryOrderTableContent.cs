using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class DeliveryOrderTableContent
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Count { get; set; }

        public DeliveryOrderTableContent(int? id, int productId, string name, double count)
        {
            Id = id;
            ProductId = productId;
            Name = name;
            Count = count;
        }
    }
}
