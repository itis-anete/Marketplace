using System;
using System.Threading.Tasks.Dataflow;
using Marketplace.Core;

namespace Marketplace.AuctionDomain
{
    public class Auctioneer : IAuctioneer
    {
        public bool AcceptBet(Auction auction, Bet bet)
        {
            if (auction.IsCompleted)
            {
                return false;
            }
            
            if (auction.AllBets.Count == 0)
            {
                return HandleBet(auction, bet, IsBetCorrectAsFirst);
            }

            if (bet.AmountInUsDollars >= auction.FinalPriceInUsDollars)
            {
                auction.Winner = bet.Bettor;
                return true;
            }

            return HandleBet(auction, bet, IsBetCorrect);
        }

        private static bool HandleBet(Auction auction, Bet bet, Func<Auction, Bet, bool> predicate)
        {
            if (!predicate(auction, bet))
            {
                return false;
            }
            
            auction.AllBets.Add(bet);
            return true;
        }
        
        private static bool IsBetCorrectAsFirst(Auction auction, Bet firstBet) 
            => firstBet.AmountInUsDollars >= auction.StartPriceInUsDollars;
        
        private static bool IsBetCorrect(Auction auction, Bet bet)
            => bet.AmountInUsDollars >= auction.LastBet.AmountInUsDollars + auction.BetMinimalStepInUsDollars;
    }
}