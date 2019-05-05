using System;
using System.Linq;
using Marketplace.Core;
using Marketplace.Core.Discounts;
using Microsoft.AspNetCore.Mvc;
using Marketplace.DbAccess;
using Marketplace.DiscountDomain;

namespace Marketplace.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class DiscountController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDiscountCalculator discountCalculator;

        public DiscountController(IUnitOfWork unitOfWork, IDiscountCalculator discountCalculator)
        {
            this.unitOfWork = unitOfWork;
            this.discountCalculator = discountCalculator;
        }

        [HttpGet]
        public IActionResult GetProductDiscountPrice(Guid productId, string customerLogin)
        {
            var product = unitOfWork.ProductRepository.GetProductById(productId);
            var customer = unitOfWork.CustomerRepository.GetCustomerByLogin(customerLogin);
            
            if (product == null || customer == null)
            {
                return BadRequest();
            }
            
            var discountPrice = discountCalculator.CalculateProductDiscountForCustomer(product, customer);
            return Ok(discountPrice);
        }
        
        [HttpPost]
        public IActionResult AddBaseDiscountToProduct(Guid productId, DiscountBase discountBase)
            => AddDiscountToProduct(productId, discountBase);

        [HttpPost]
        public IActionResult AddQuantityDiscountToProduct(Guid productId, QuantityDiscount quantityDiscount)
            => AddDiscountToProduct(productId, quantityDiscount);

        [HttpPost]
        public IActionResult AddBirthdayDiscountToProduct(Guid productId, BirthdayDiscount birthdayDiscount)
            => AddDiscountToProduct(productId, birthdayDiscount);

        [HttpDelete]
        public IActionResult RemoveDiscount(Guid productId, Guid discountId)
        {
            var product = unitOfWork.ProductRepository.GetProductById(productId);
            
            if (product == null)
            {
                return BadRequest();
            }

            var discountToRemove = product.Discounts
                .FirstOrDefault(discount => discount.Id == discountId);
            
            if (discountToRemove == null)
            {
                return BadRequest();
            }

            product.Discounts.Remove(discountToRemove);
            unitOfWork.ProductRepository.UpdateProduct(product);

            return Ok();
        }
        
        private IActionResult AddDiscountToProduct(Guid productId, DiscountBase discount)
        {
            var product = unitOfWork.ProductRepository.GetProductById(productId);

            if (product == null )
            {
                return BadRequest();
            }
            
            product.Discounts.Add(discount);
            unitOfWork.ProductRepository.UpdateProduct(product);
            return Ok();
        }
    }
}