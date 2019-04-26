using Marketplace.Core;

namespace Marketplace.CartDomain
{
    public interface ICartTotalCalculator
    {
        void CalculateTotal(Cart cart);
    }
}