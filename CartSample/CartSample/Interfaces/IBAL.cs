using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartSample.Interfaces
{
    public interface IBAL
    {
        Task<IEnumerable<Product>> CalculateDiscountScenario();
    }
}
