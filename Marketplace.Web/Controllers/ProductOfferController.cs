﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Infrastructure.UnitOfWork;
using Marketplace.Models.ProductData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Web.Controllers
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
            return await _unitOfWork.ProductOfferRepository
                .Get(x => x.Id == id)
                .Include(m => m.Market).Include(p => p.Product).FirstOrDefaultAsync();
        }

        [HttpGet("[action]/{marketId}")]
        public async Task<IEnumerable<ProductOffer>> GetProductsOfferByMarket(int marketId)
        {
            return await _unitOfWork.ProductOfferRepository
                .Get(x => x.MarketId == marketId)
                .Include(m => m.Market).Include(p => p.Product).ToListAsync();
        }

        [HttpGet("[action]/{productOfferId}")]
        public async Task<IEnumerable<ProductOffer>> GetCompetitiveProductsOffers(int productOfferId)
        {
            var productOffer = _unitOfWork.ProductOfferRepository.Get(x => x.Id == productOfferId).FirstOrDefault();

            return await _unitOfWork.ProductOfferRepository
                .Get(x => x.ProductId == productOffer.ProductId && x.MarketId != productOffer.MarketId)
                .Include(m => m.Market).Include(p => p.Product).ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProductOffer([FromBody]ProductOffer productOffer)
        {
            if (_unitOfWork.ProductOfferRepository.Get().Any(x => x.MarketId == productOffer.MarketId && x.ProductId == productOffer.ProductId && x.Price == productOffer.Price))
                return BadRequest(productOffer);

            _unitOfWork.ProductOfferRepository.Insert(productOffer);

            await _unitOfWork.Save();

            return Ok(productOffer);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProductOffer([FromBody]ProductOffer updatedProductOffer)
        {
            var productOffer = _unitOfWork.ProductOfferRepository
                .Get(x => x.Id == updatedProductOffer.Id)
                .Include(m => m.Market).Include(p => p.Product).FirstOrDefault();

            productOffer.Price = updatedProductOffer.Price;

            productOffer.Description = updatedProductOffer.Description;

            productOffer.Image = updatedProductOffer.Image;

            _unitOfWork.ProductOfferRepository.Update(productOffer);

            await _unitOfWork.Save();

            return Ok(productOffer);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProductOffer(int id)
        {
            var productOffer = _unitOfWork.ProductOfferRepository.Get(x => x.Id == id).FirstOrDefault();

            _unitOfWork.ProductOfferRepository.Delete(productOffer);

            await _unitOfWork.Save();

            return Ok(productOffer);
        }
    }
}
