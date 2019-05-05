using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    internal class PgAuctionRepository : PgRepositoryBase, IAuctionRepository
    {
        public PgAuctionRepository(ApplicationContext applicationContext) 
            : base(applicationContext)
        {
        }

        public void AddAction(Auction newAuction)
        {
            applicationContext.Auctions.Add(newAuction);
            applicationContext.SaveChanges();
        }

        public Auction GetAuctionById(Guid auctionId)
        {
            return applicationContext.Auctions.Find(auctionId);
        }

        public void UpdateAuction(Auction updatedAuction)
        {
            applicationContext.Auctions.Update(updatedAuction);
            applicationContext.SaveChanges();
        }

        public void RemoveAuction(Guid auctionId)
        {
            var auctionToRemove = applicationContext.Auctions.Find(auctionId);
            if (auctionToRemove == null)
            {
                return;
            }

            applicationContext.Auctions.Remove(auctionToRemove);
        }

        public IEnumerable<Auction> GetAllAuctions()
        {
            return applicationContext.Auctions;
        }

        public IEnumerable<Auction> GetMarketAuctions(string marketName)
        {
            return applicationContext.Auctions
                .Where(auction => auction.MarketName == marketName);
        }
    }
}