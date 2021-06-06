using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Models
{
    public class GoodsDocument
    {
        public int Id { get; set; }
        public DateTime DateIssued { get; set; }

        /**
         * Internal - 0
         * External - 1
         */
        public int Source { get; set; }

        /**
         * Incoming - 0
         * Outgoing - 1
         */
        public int Destination { get; set; }

        public IList<ProductItem> productItems { get; set; }
        public IList<Item> items { get; set; }
        
    }   
}