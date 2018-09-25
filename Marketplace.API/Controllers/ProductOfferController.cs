using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Infrastructure.UnitOfWork;
using Marketplace.Models.ProductData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductOfferController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductOfferController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductOffer>> GetProductOffers()
        {
            return await _unitOfWork.ProductOfferRepository.Get().ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ProductOffer> GetProductOfferById(int id)
        {
            return await _unitOfWork.ProductOfferRepository.Get(x => x.Id == id).Include(m => m.Market).Include(p => p.Product).FirstOrDefaultAsync();
        }

        [HttpGet("[action]/{marketId}")]
        public async Task<IEnumerable<ProductOffer>> GetProductsOfferByMarket(int marketId)
        {
            return await _unitOfWork.ProductOfferRepository.Get(x => x.MarketId == marketId).Include(m => m.Market).Include(p => p.Product).ToListAsync();
        }

        [HttpGet("[action]/{productId}")]
        public async Task<IEnumerable<ProductOffer>> GetProductsOfferByProduct(int productId)
        {
            return await _unitOfWork.ProductOfferRepository.Get(x => x.ProductId == productId).Include(m => m.Market).Include(p => p.Product).ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProductOffer([FromBody]ProductOffer marketProduct)
        {
            if (_unitOfWork.ProductOfferRepository.Get().Any(x => x.MarketId == marketProduct.MarketId && x.ProductId == marketProduct.ProductId))
                return BadRequest(marketProduct);

            _unitOfWork.ProductOfferRepository.Insert(marketProduct);

            await _unitOfWork.Save();

            return Ok(marketProduct);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProductOffer(ProductOffer productOffer)
        {
            _unitOfWork.ProductOfferRepository.Update(productOffer);

            await _unitOfWork.Save();

            return Ok(productOffer);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteProductOffer(int id)
        {
            var productOffer = _unitOfWork.ProductOfferRepository.Get(x => x.Id == id).FirstOrDefault();

            _unitOfWork.ProductOfferRepository.Delete(productOffer);

            await _unitOfWork.Save();

            return Ok(productOffer);
        }
    }
}
