using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Infrastructure.UnitOfWork;
using Marketplace.Models;
using Microsoft.AspNetCore.Mvc;

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
            return await _unitOfWork.MarketRepository.Get();
        }
    }
}
