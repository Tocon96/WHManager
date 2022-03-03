using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class ContrahentReportData
    {
        public int Id { get; set; }
        public int ContrahentId { get; set; }
        public string ContrahentName { get; set; }
        public DateTime DateRealized { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
