using System;
using System.Linq;
using Marketplace.AuctionDomain;
using Marketplace.Core;
using Microsoft.AspNetCore.Mvc;
using Marketplace.DbAccess;

namespace Marketplace.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class AuctionController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAuctioneer auctioneer;

        public AuctionController(IUnitOfWork unitOfWork, IAuctioneer auctioneer)
        {
            this.unitOfWork = unitOfWork;
            this.auctioneer = auctioneer;
        }

        [HttpGet]
        public IActionResult GetAllMarketAuction(string marketName)
        {
            var auctions = unitOfWork.AuctionRepository.GetMarketAuctions(marketName);

            if (!auctions.Any())
            {
                return NotFound();
            }

            return Ok(auctions);
        }
        
        [HttpPost]
        public IActionResult CreateAuction(Auction newAuction)
        {
            var allAuctions = unitOfWork.AuctionRepository.GetAllAuctions();

            if (allAuctions.Any(auction => auction.ProductLotId == newAuction.ProductLotId))
            {
                return BadRequest();
            }
            
            unitOfWork.AuctionRepository.AddAction(newAuction);
            return Ok();
        }

        [HttpPost]
        public IActionResult SetBet(Guid auctionId, Bet bet)
        {
            var auction = unitOfWork.AuctionRepository.GetAuctionById(auctionId);

            if (auction == null)
            {
                return BadRequest();
            }

            var isBetAccepted = auctioneer.AcceptBet(auction, bet);

            return Ok(isBetAccepted);
        }
    }
}