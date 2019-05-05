namespace Marketplace.Core.Discounts
{
    public class QuantityDiscount : DiscountBase
    {
        private QuantityDiscount()
        {
        }

        public QuantityDiscount(double percent, uint quantityWhenDiscountEnables)
            : base(percent)
        {
            QuantityWhenDiscountEnables = quantityWhenDiscountEnables;
        }
        
        public uint QuantityWhenDiscountEnables { get; private set; }
    }
}