using Marketplace.Core;

namespace Marketplace.AuctionDomain
{
    public interface IAuctioneer
    {
        bool AcceptBet(Auction auction, Bet bet);
    }
}