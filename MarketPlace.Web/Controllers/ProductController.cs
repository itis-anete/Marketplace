using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Marketplace.Core;
using Marketplace.DbAccess;
using Marketplace.ProductDomain;

namespace Marketplace.Web.Controllers
{
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
    }
}