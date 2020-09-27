using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public double Nip { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
