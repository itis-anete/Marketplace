using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Infrastructure.UnitOfWork;
using Marketplace.Models;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
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
            return await _unitOfWork.ProductRepository.Get();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProduct([FromBody]Product product)
        {
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

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = _unitOfWork.ProductRepository.Get(x => x.Id == id).Result.FirstOrDefault();

            _unitOfWork.ProductRepository.Delete(product);

            await _unitOfWork.Save();

            return Ok(product);
        }
    }
}
