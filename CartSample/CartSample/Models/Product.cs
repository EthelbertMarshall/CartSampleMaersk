using CartSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartSample
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int DiscountQty { get; set; }
        public int DiscountPrice { get; set; }

        public List<Cart> Carts { get; set; }
    }
}
