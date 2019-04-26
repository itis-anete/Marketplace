namespace Marketplace.Core.Discounts
{
    public class QuantityDiscount : DiscountBase
    {
        private QuantityDiscount()
        {
        }

        public QuantityDiscount(double percent, int quantityWhenDiscountEnables)
            : base(percent)
        {
            QuantityWhenDiscountEnables = quantityWhenDiscountEnables;
        }
        
        public int QuantityWhenDiscountEnables { get; private set; }
    }
}