using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Tax
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(3)]
        public int Value { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
