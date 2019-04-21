using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MarketPlace.Core;
using MarketPlace.DbAccess;

namespace MarketPlace.Web.Controllers
{
    public class MarketController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public MarketController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IActionResult GetAllMarkets()
        {
            return Ok(unitOfWork.MarketRepository.GetAllMarkets());
        }
        
        [HttpPost]
        public IActionResult CreateMarket(Market newMarket)
        {
            unitOfWork.MarketRepository.AddMarket(newMarket);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetMarketByName(string marketName)
        {
            var foundMarket = unitOfWork.MarketRepository.GetMarketByName(marketName);

            if (foundMarket != null)
            {
                return Ok(foundMarket);
            }

            return BadRequest();
        }

        public IActionResult GetMarketsByCategory(string categoryName)
        {
            var markets = unitOfWork.MarketRepository.GetMarketsByCategory(categoryName);

            if (markets.Any())
            {
                return Ok(markets);
            }

            return NotFound();
        }
    }
}