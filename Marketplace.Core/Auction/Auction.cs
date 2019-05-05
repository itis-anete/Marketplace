using System;
using System.Collections.Generic;
using System.Linq;
using Marketplace.Infrastructure;

namespace Marketplace.Core
{
    public class Auction
    {       
        private Auction()
        {
        }

        public Auction(Guid productLotId, string marketName, DateTime completionDateTime, double startPriceInUsDollars,
            double betMinimalStepInUsDollars, double? finalPriceInUsDollars = null)
        {
            Id = Guid.NewGuid();
            ProductLotId = productLotId;
            MarketName = marketName.CheckValue();
            CompletionDateTime = completionDateTime;
            StartPriceInUsDollars = startPriceInUsDollars;
            BetMinimalStepInUsDollars = betMinimalStepInUsDollars;
            FinalPriceInUsDollars = finalPriceInUsDollars;
        }
        
        public Guid Id { get; private set; }

        public Guid ProductLotId { get; private set; }
        
        public string MarketName { get; private set; }
        
        public string WinnerLogin { get; set; }
        
        public double StartPriceInUsDollars { get; private set; }
        
        public double? FinalPriceInUsDollars { get; private set; }
        
        public double BetMinimalStepInUsDollars { get; private set; }
        
        public DateTime CompletionDateTime { get; private set; }

        public bool IsCompleted => CompletionDateTime <= DateTime.Now || WinnerLogin != null;
        
        public List<Bet> AllBets { get; private set; }

        public Bet LastBet => AllBets[AllBets.Count - 1];
    }
}