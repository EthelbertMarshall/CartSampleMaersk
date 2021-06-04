using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CartSample.Interfaces;
using CartSample.Models;
using Newtonsoft.Json;

namespace CartSample
{
    public class DAL :IDAL
    {
        public DAL()
        {

        }
        public async Task<int> CalculateDiscountScenario(Product product, Cart cart)
        {

            int discountPrice = 0;
            try
            {
   

            if (product != null && cart != null)
            {
                if (product.ProductPrice < 0)
                {
                    throw new ArgumentOutOfRangeException("Price");
                }

                if (cart.Quantity == product.DiscountQty)
                {
                    discountPrice = product.ProductPrice;
                }
                else if (cart.Quantity > product.DiscountQty)
                {
                    var res = Math.Abs(cart.Quantity - product.DiscountQty);

                    int times = 1;

                    if (res > product.DiscountQty)
                    {
                        times = Math.Abs(cart.Quantity / product.DiscountQty);
                        discountPrice = times * product.DiscountPrice + product.ProductPrice;
                    }
                    else
                    {
                        discountPrice = product.DiscountPrice + times * res * product.ProductPrice;
                    }


                }
                else if (cart.Quantity < product.DiscountQty)
                {
                    discountPrice = cart.Quantity * product.ProductPrice;
                }
                else
                {
                    discountPrice = product.ProductPrice;
                }

            };

           
            }
            catch (Exception ex)
            {

                throw ex;
            }

            await Task.CompletedTask;
            return discountPrice;
        }

    }
}

