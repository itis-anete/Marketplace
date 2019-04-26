namespace Marketplace.Core.Discounts
{
    public class BirthdayDiscount : DiscountBase
    {
        private BirthdayDiscount()
        {
        }
        
        public BirthdayDiscount(double percent, int dateRangeInDays) 
            : base(percent)
        {
            DateRangeInDays = dateRangeInDays;
        }
        
        public int DateRangeInDays { get; private set; }
    }
}