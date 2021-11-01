﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class OutgoingDocument
    {
        public int Id { get; set; }
        public Client Contrahent { get; set; }
        public DateTime DateSent { get; set; }
        public int OrderId { get; set; }
    }
}
