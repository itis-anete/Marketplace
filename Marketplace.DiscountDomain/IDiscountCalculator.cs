using Marketplace.Core;

namespace Marketplace.DiscountDomain
{
    public interface IDiscountCalculator
    {
        double CalculateProductDiscountForCustomer(Product product, Customer customer);
    }
}