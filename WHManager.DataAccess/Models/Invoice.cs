using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateIssued { get; set; }
        [Required]
        public Client Client { get; set; }
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }
    }
}
