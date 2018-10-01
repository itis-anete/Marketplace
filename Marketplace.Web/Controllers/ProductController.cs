using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Infrastructure.UnitOfWork;
using Marketplace.Models.ProductData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _unitOfWork.ProductRepository.Get().ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
            if (_unitOfWork.ProductRepository.Get().Any(x => x.Name == product.Name))
                return BadRequest(product);

            _unitOfWork.ProductRepository.Insert(product);

            await _unitOfWork.Save();

            return Ok(product);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProduct([FromBody]Product product)
        {
            _unitOfWork.ProductRepository.Update(product);

            await _unitOfWork.Save();

            return Ok(product);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _unitOfWork.ProductRepository.Get(x => x.Id == id).FirstOrDefault();

            _unitOfWork.ProductRepository.Delete(product);

            await _unitOfWork.Save();

            return Ok(product);
        }
    }
}
