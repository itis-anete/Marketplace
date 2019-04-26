using System;

namespace Marketplace.Core.Discounts
{
    public class DiscountBase
    {
        protected DiscountBase()
        {
        }

        public DiscountBase(double percent)
        {
            Percent = percent;
        }
     

        private double percent;
        public double Percent
        {
            get => percent;
            private set
            {
                if (value <= 0) percent = 0;
                if (value >= 100) percent = 100;
                percent = value;
            }
        }
        
        public DateTimeOffset EndDate { get; private set; }

        public bool IsActive => EndDate <= DateTimeOffset.Now;
    }
}