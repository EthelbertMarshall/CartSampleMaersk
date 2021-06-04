using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartSample.Models
{
    public class Cart
    {
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int ItemCount { get; set; }
        public int CartCount { get; set; }
    }
}
