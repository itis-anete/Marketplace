using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DBRepository.Factories;
using DBRepository.Interfaces;
using DBRepository.Repositories;
using Models;

namespace Marketplace.Controllers
{
    [Route("api/[controller]")]
    public class MarketController : Controller
    {
        readonly IMarketRepository _marketRepository;

        public MarketController(IMarketRepository marketRepository)
        {
            _marketRepository = marketRepository;
        }

        [HttpGet("[action]")]
        public async Task<List<Market>> GetMarkets()
        {
            return await _marketRepository.GetMarkets();
        }
    }
}
