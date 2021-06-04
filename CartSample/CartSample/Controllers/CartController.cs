
using CartSample.BAL;
using CartSample.Interfaces;
using CartSample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace CartSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : Controller 
    {

        private readonly IBAL _bal;

      
        public CartController(IBAL bal )
        {
            _bal = bal;
        }



        [HttpGet]
        [ActionName("CalculateDiscount")]

        public async Task<IActionResult> CalculateDiscountScenario()
        {

            var result = await _bal.CalculateDiscountScenario();
            return Ok(result);
        }

    


    }
}
