using CartSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartSample.Interfaces
{
    public interface IDAL
    {
        Task<int> CalculateDiscountScenario(Product product, Cart cart);
    }
}
