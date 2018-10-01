﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Infrastructure.UnitOfWork;
using Marketplace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Web.Controllers
{
    [Route("api/[controller]")]
    public class MarketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Market>> GetMarkets()
        {
            return await _unitOfWork.MarketRepository
                .Get()
                .Include(c => c.ProductOffers).ThenInclude(c=>c.Product).ToListAsync();
        }

        [HttpGet("[action]/{marketId}")]
        public async Task<Market> GetMarketById(int marketId)
        {
            return await _unitOfWork.MarketRepository
                .Get(x=>x.Id == marketId)
                .Include(c => c.ProductOffers).ThenInclude(c => c.Product).FirstOrDefaultAsync();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddMarket([FromBody]Market market)
        {
            if (_unitOfWork.MarketRepository.Get().Any(x => x.Name == market.Name))
                return BadRequest(market);

            _unitOfWork.MarketRepository.Insert(market);
            await _unitOfWork.Save();
            return Ok(market);

        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateMarket([FromBody]Market updatedMarket)
        {
            var market = _unitOfWork.MarketRepository.Get(x => x.Id == updatedMarket.Id).Include(c => c.ProductOffers).ThenInclude(c => c.Product).FirstOrDefault();

            market.Name = updatedMarket.Name;

            _unitOfWork.MarketRepository.Update(market);

            await _unitOfWork.Save();

            return Ok(market);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteMarket(int id)
        {
            var market = _unitOfWork.MarketRepository.Get(x => x.Id == id).FirstOrDefault();

            _unitOfWork.MarketRepository.Delete(market);

            await _unitOfWork.Save();

            return Ok(market);
        }
    }
}
