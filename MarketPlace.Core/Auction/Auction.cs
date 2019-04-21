using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketPlace.Core
{
    public class Auction
    {
        private List<Bet> allBets;
        
        private Auction()
        {
        }

        public Auction(Product lot, Market market, DateTime completionDateTime, double startPriceInUsDollars,
            double betMinimalStepInUsDollars, double? finalPriceInUsDollars = null)
        {
            Lot = lot;
            Market = market;
            CompletionDateTime = completionDateTime;
            StartPriceInUsDollars = startPriceInUsDollars;
            BetMinimalStepInUsDollars = betMinimalStepInUsDollars;
            FinalPriceInUsDollars = finalPriceInUsDollars;
        }
        
        public Guid Id { get; private set; }

        public Product Lot { get; private set; }
        
        public Market Market { get; private set; }
        
        public double StartPriceInUsDollars { get; private set; }
        
        public double? FinalPriceInUsDollars { get; private set; }
        
        public double BetMinimalStepInUsDollars { get; private set; }
        
        public DateTime CompletionDateTime { get; private set; }

        public bool IsCompleted => CompletionDateTime <= DateTime.Now;
        
        public IEnumerable<Bet> AllBets => allBets;

        public Bet LastBet => allBets[allBets.Count - 1];
    }
}