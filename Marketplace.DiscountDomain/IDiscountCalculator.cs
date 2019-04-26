using Marketplace.Core;

namespace Marketplace.DiscountDomain
{
    public interface IDiscountCalculator
    {
        void CalculateProductDiscountForCustomer(Product product, Customer customer);
    }
}