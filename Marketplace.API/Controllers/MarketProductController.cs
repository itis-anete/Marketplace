using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Infrastructure.UnitOfWork;
using Marketplace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    public class MarketProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarketProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<MarketProduct>> GetMarketProducts()
        {
            return await _unitOfWork.MarketProductRepository.Get().ToListAsync();
        }

        [HttpGet("[action]/{marketId}")]
        public async Task<IEnumerable<MarketProduct>> GetMarketProduct(int marketId)
        {
            return await _unitOfWork.MarketProductRepository.Get(x=>x.MarketId == marketId).Include(c => c.Market).Include(c => c.Product).ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddMarketProduct([FromBody]MarketProduct marketProduct)
        {
            if (!_unitOfWork.MarketProductRepository.Get().Any(x =>
                x.MarketId == marketProduct.MarketId && x.ProductId == marketProduct.ProductId))
            {
                _unitOfWork.MarketProductRepository.Insert(marketProduct);

                await _unitOfWork.Save();

                return Ok(marketProduct);
            }

            return BadRequest(marketProduct);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateMarketProduct(MarketProduct marketProduct)
        {
            _unitOfWork.MarketProductRepository.Update(marketProduct);

            await _unitOfWork.Save();

            return Ok(marketProduct);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteMarketProduct(int id)
        {
            var marketProduct = _unitOfWork.MarketProductRepository.Get(x => x.Id == id).FirstOrDefault();

            _unitOfWork.MarketProductRepository.Delete(marketProduct);

            await _unitOfWork.Save();

            return Ok(marketProduct);
        }
    }
}
