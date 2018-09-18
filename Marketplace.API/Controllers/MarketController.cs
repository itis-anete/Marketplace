using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Infrastructure.UnitOfWork;
using Marketplace.Models;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
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
            return await _unitOfWork.MarketRepository.Get();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddMarket([FromBody]Market market)
        {
            _unitOfWork.MarketRepository.Insert(market);

            await _unitOfWork.Save();

            return Ok(market);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateMarket([FromBody]Market market)
        {
            _unitOfWork.MarketRepository.Update(market);

            await _unitOfWork.Save();

            return Ok(market);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteMarket(int id)
        {
            var market = _unitOfWork.MarketRepository.Get(x => x.Id == id).Result.FirstOrDefault();

            _unitOfWork.MarketRepository.Delete(market);

            await _unitOfWork.Save();

            return Ok(market);
        }
    }
}
