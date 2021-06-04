using CartSample.Interfaces;
using CartSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartSample.BAL
{
    public class BusinessLogic : IBAL 
    {
        private readonly List<Cart> _cartItems;
        private readonly List<Product> _products;
        private readonly IDAL _dal;

        public BusinessLogic(IDAL dal)
        {
            _dal = dal;
           _products = InitializeProducts();
            _cartItems = InitializeCart();
        
        }
 
        private List<Product> InitializeProducts()
        {
            List<Product> products = new List<Product>
            {
                new  Product { ProductId = 1, ProductName = "A", ProductPrice = 50, DiscountPrice = 130, DiscountQty = 3 },

                new  Product { ProductId = 2, ProductName = "B", ProductPrice = 30, DiscountPrice = 45, DiscountQty = 2 },

                new  Product { ProductId = 3, ProductName = "C", ProductPrice = 20, DiscountPrice = 15, DiscountQty = 1 },

                new  Product { ProductId = 4, ProductName = "D", ProductPrice = 15, DiscountPrice = 15, DiscountQty = 1 },

                //new  Product { ProductId = 1, ProductName = "A", ProductPrice = 50, DiscountPrice = 130, DiscountQty = 3 },

                //new  Product { ProductId = 2, ProductName = "B", ProductPrice = 30, DiscountPrice = 45, DiscountQty = 2 },

                //new  Product { ProductId = 3, ProductName = "C", ProductPrice = 20, DiscountPrice = 15, DiscountQty = 1 },

                //new  Product { ProductId = 4, ProductName = "D", ProductPrice = 15, DiscountPrice = 15, DiscountQty = 1 },

            };

            return products;
        }

        private List<Cart> InitializeCart()
        {
            List<Cart> cartItems = new List<Cart>
            {
                new  Cart { ProductId = 1,  Quantity=5 , CartCount=5 , ItemCount=5, Price=0 },
                new  Cart { ProductId = 2,  Quantity=5 , CartCount=5 , ItemCount=5, Price=0  },
                new  Cart { ProductId = 3,  Quantity=1 , CartCount=1 , ItemCount=1, Price=0  },


                //new  Cart { ProductId = 1,  Quantity=1 , CartCount=1 , ItemCount=1, Price=0 },
                //new  Cart { ProductId = 2,  Quantity=1 , CartCount=1 , ItemCount=1, Price=0  },
                //new  Cart { ProductId = 3,  Quantity=1 , CartCount=1 , ItemCount=1, Price=0  },
            };

            return cartItems;
        }


        public async Task<IEnumerable<Product>> CalculateDiscountScenario()
        {
            var input = _products;
            var cartItems = _cartItems;
            var totalPrice = 0;

            foreach (var item in cartItems)
            {
                Console.WriteLine("Cart Items {0}-{1}-{2}", item.ProductId, item.Price, item.Quantity);

                var prods = input.Where(x => x.ProductId == item.ProductId).ToList();

                foreach (var prod in prods)
                {
                    prod.DiscountPrice = await _dal.CalculateDiscountScenario(prod, item);

                    totalPrice = totalPrice + prod.DiscountPrice;

                    Console.WriteLine("Products {0}-{1}-{2}-{3}", prod.ProductName, prod.ProductPrice, prod.DiscountQty, prod.DiscountPrice);

                }

            }

            await Task.CompletedTask;
            Console.WriteLine("TotalPrice -- " + totalPrice);
            return _products;
        }
    }
}
