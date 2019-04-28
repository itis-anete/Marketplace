using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Core;
using Marketplace.DbAccess;

namespace Marketplace.Web.Controllers
{
    [Route("[controller]/[action]")]
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
        public IActionResult UpdateMarket(Market updatedMarket)
        {
            unitOfWork.MarketRepository.UpdateMarket(updatedMarket);
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

            return NotFound();
        }

        [HttpGet]
        public IActionResult GetMarketsByCategory(ProductCategory productCategory)
        {
            var markets = unitOfWork.MarketRepository.GetMarketsByCategory(productCategory);

            if (markets.Any())
            {
                return Ok(markets);
            }

            return NotFound();
        }
    }
}