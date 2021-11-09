using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.DataAccess.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Admin { get; set; }
        public bool Business { get; set; }
        public bool Contractors { get; set; } 
        public bool Documents {get; set;}
        public bool Warehouse { get; set; }
        public bool Report { get; set; }
        public ICollection<User> Users { get; set; }
    }
}