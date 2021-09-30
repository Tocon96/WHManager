using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class IncomingDocument
    {
        public int Id { get; set; }
        public Provider Provider { get; set; }
        public DateTime DateReceived { get; set; }
        public int DeliveryId { get; set; }
    }
}
