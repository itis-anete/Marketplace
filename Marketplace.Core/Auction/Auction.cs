using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace.Core
{
    public class Auction
    {       
        private Auction()
        {
        }

        public Auction(Product lot, Market market, DateTime completionDateTime, double startPriceInUsDollars,
            double betMinimalStepInUsDollars, double? finalPriceInUsDollars = null)
        {
            Id = Guid.NewGuid();
            Lot = lot ?? throw new ArgumentNullException(nameof(lot));
            Market = market ?? throw new ArgumentNullException(nameof(market));
            CompletionDateTime = completionDateTime;
            StartPriceInUsDollars = startPriceInUsDollars;
            BetMinimalStepInUsDollars = betMinimalStepInUsDollars;
            FinalPriceInUsDollars = finalPriceInUsDollars;
        }
        
        public Guid Id { get; private set; }

        public Product Lot { get; private set; }
        
        public Market Market { get; private set; }
        
        public Customer Winner { get; set; }
        
        public double StartPriceInUsDollars { get; private set; }
        
        public double? FinalPriceInUsDollars { get; private set; }
        
        public double BetMinimalStepInUsDollars { get; private set; }
        
        public DateTime CompletionDateTime { get; private set; }

        public bool IsCompleted => CompletionDateTime <= DateTime.Now || Winner != null;
        
        public List<Bet> AllBets { get; set; }

        public Bet LastBet => AllBets[AllBets.Count - 1];
    }
}