using System;
using System.Linq;
using Marketplace.Core;
using Marketplace.DbAccess;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ReviewController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ReviewController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult AddReview(Guid productId, Review newReview)
        {
            var productToReview = unitOfWork.ProductRepository.GetProductById(productId);
            if (productToReview == null)
            {
                return BadRequest();
            }

            var isCustomerOrderedProduct = unitOfWork.OrderRepository
                .GetAllCustomerOrders(newReview.CustomerLogin)
                .Any(order => order.Products.Any(product => product.Id == productId));

            if (!isCustomerOrderedProduct)
            {
                return Forbid();
            }
            
            productToReview.Reviews.Add(newReview);
            unitOfWork.ProductRepository.UpdateProduct(productToReview);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateReview(Guid productId, Review updatedReview)
        {
            var productToReview = unitOfWork.ProductRepository.GetProductById(productId);
            if (productToReview == null)
            {
                return NotFound();
            }

            var oldReview = productToReview.Reviews
                .FirstOrDefault(review => review.Id == updatedReview.Id);

            if (oldReview == null)
            {
                return NotFound();
            }

            productToReview.Reviews.Remove(oldReview);
            productToReview.Reviews.Add(updatedReview);

            return Ok();
        }
    }
}