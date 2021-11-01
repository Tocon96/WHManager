using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime DateIssued { get; set; }
        public Client Client { get; set; }
        public int OrderId { get; set; }
    }
}
