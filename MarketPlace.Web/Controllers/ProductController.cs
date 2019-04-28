using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Marketplace.Core;
using Marketplace.DbAccess;
using Marketplace.ProductDomain;

namespace Marketplace.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISameProductsFinder sameProductsFinder;

        public ProductController(IUnitOfWork unitOfWork, ISameProductsFinder sameProductsFinder)
        {
            this.unitOfWork = unitOfWork;
            this.sameProductsFinder = sameProductsFinder;
        }

        [HttpGet]
        public IActionResult GetSameProducts(Product product)
        {
            var sameProducts = sameProductsFinder.GetSameProducts(product);

            if (sameProducts.Any())
            {
                return Ok(sameProducts);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddProduct(Product newProduct)
        {            
            unitOfWork.ProductRepository.AddProduct(newProduct);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product updatedProduct)
        {           
            unitOfWork.ProductRepository.UpdateProduct(updatedProduct);
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveProduct(Product productToRemove)
        {
            unitOfWork.ProductRepository.RemoveProduct(productToRemove);
            return Ok();
        }
    }
}