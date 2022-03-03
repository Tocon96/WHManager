using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class ContrahentReports
    {
        public int Id { get; set; }
        public string ReportOrigin { get; set; }
        public int ContrahentId { get; set; }
        public string ContrahentName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}