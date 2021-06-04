using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartSample.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using CartSample.Models;

namespace CartSample.Controllers.Tests
{
    [TestClass()]
    public class CartControllerTests
    {
        private DAL _dal;

      
        public CartControllerTests()
        {
            
        }
        [TestMethod()]
        public void  CalculateDiscountScenarioTestNegativeValues()
        {

            var prod = new Product { ProductId = 1, ProductName = "A", ProductPrice = -50, DiscountPrice = 130, DiscountQty = 3 };
            var cart  = new Cart { ProductId = 1, Quantity = 5, CartCount = 5, ItemCount = 5, Price = 0 };

            var result = _dal.CalculateDiscountScenario(prod, cart);
             
            Assert.AreEqual(prod, result, "Price is Negative");
            
        }

        [TestMethod()]
        public void CalculateDiscountScenarioProductQuantityNegative()
        {
            var prod = new Product { ProductId = 1, ProductName = "A", ProductPrice = 50, DiscountPrice = 130, DiscountQty = 3 };
            var cart = new Cart { ProductId = 1, Quantity = -5, CartCount = 5, ItemCount = 5, Price = 0 };

            var result = _dal.CalculateDiscountScenario(prod, cart);

            Assert.AreEqual(prod, result, "Quantity is Negative");
        }

        [TestMethod()]
        public void CalculateDiscountScenarioTestProductisEmpty()
        {

            Product prod = new Product();
            var cart = new Cart { ProductId = 1, Quantity = -5, CartCount = 5, ItemCount = 5, Price = 0 };
            var result = _dal.CalculateDiscountScenario(prod, cart);

            Assert.AreEqual(prod, result, "Product is Empty");
        }

        [TestMethod()]
        public void CalculateDiscountScenarioTestCartisEmpty()
        {

            var prod = new Product { ProductId = 1, ProductName = "A", ProductPrice = 50, DiscountPrice = 130, DiscountQty = 3 };
            Cart cart = new Cart();
            var result = _dal.CalculateDiscountScenario(prod, cart);

            Assert.AreEqual(prod, result, "Cart is Empty");
        }

        [TestMethod()]
        public void CalculateDiscountScenarioPass()
        {

            var prod = new Product { ProductId = 1, ProductName = "A", ProductPrice = 50, DiscountPrice = 130, DiscountQty = 3 };
            var cart = new Cart { ProductId = 1, Quantity = 5, CartCount = 5, ItemCount = 5, Price = 0 };

            var result = _dal.CalculateDiscountScenario(prod, cart);

            Assert.AreEqual(prod, result, "Test Passed");
        }

        [TestMethod()]
        public void CalculateDiscountScenarioFail()
        {

            var prod = new Product { ProductId = 1, ProductName = "A", ProductPrice = 50, DiscountPrice = 130, DiscountQty = 3 };
            var cart = new Cart { ProductId = 1, Quantity = 5, CartCount = 5, ItemCount = 5, Price = 0 };

            var result = _dal.CalculateDiscountScenario(prod, cart);

            Assert.AreNotEqual(prod, result, "Test Passed");
        }
    }
}