using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class ProductType
    {
        public  int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<TypeReports> Reports { get; set; }
    }
}
