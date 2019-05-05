using System;
using Marketplace.Infrastructure;

namespace Marketplace.Core
{
    public class Bet
    {
        private Bet()
        {
        }

        public Bet(string bettorLogin, double amountInUsDollars)
        {
            Id = Guid.NewGuid();
            BettorLogin = bettorLogin.CheckValue();
            AmountInUsDollars = amountInUsDollars;
            CreationDateTime = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public string BettorLogin { get; private set; }

        public double AmountInUsDollars { get; private set; }

        public DateTime CreationDateTime { get; private set; }
    }
}