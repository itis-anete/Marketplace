using System;
using System.Collections.Generic;
using Marketplace.Core;

namespace Marketplace.DbAccess
{
    public interface IAuctionRepository
    {
        void AddAction(Auction newAuction);

        Auction GetAuctionById(Guid auctionId);

        void UpdateAuction(Auction updatedAuction);

        void RemoveAuction(Guid auctionId);

        IEnumerable<Auction> GetAllAuctions();

        IEnumerable<Auction> GetMarketAuctions(string marketName);
    }
}