using System;
using Marketplace.CartDomain;
using Marketplace.Core;
using Marketplace.DbAccess;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICartTotalCalculator cartTotalCalculator;

        public CartController(IUnitOfWork unitOfWork, ICartTotalCalculator cartTotalCalculator)
        {
            this.unitOfWork = unitOfWork;
            this.cartTotalCalculator = cartTotalCalculator;
        }

        [HttpPut]
        public IActionResult AddProductToCustomerCart(string customerLogin, Guid productId, uint quantity = 1)
        {
            var product = unitOfWork.ProductRepository.GetProductById(productId);

            if (product == null)
            {
                return BadRequest();
            }
            
            if (product.Quantity < quantity)
            {
                return BadRequest();
            }
            
            product.Quantity -= quantity;
            unitOfWork.ProductRepository.UpdateProduct(product);

            var cart = unitOfWork.CartRepository.GetCustomerCart(customerLogin);
            product.Quantity = quantity;
            cart.Products.Add(product);
            unitOfWork.CartRepository.UpdateCart(cart);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetCustomerCart(string customerLogin)
        {
            var customerCart = unitOfWork.CartRepository.GetCustomerCart(customerLogin);

            if (customerCart == null)
            {
                return NotFound();
            }

            return Ok(customerCart);
        }
    }
}