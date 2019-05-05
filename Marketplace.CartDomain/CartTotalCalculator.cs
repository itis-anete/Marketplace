using System;
using System.Linq;
using Marketplace.Core;
using Marketplace.DiscountDomain;

namespace Marketplace.CartDomain
{
    public class CartTotalCalculator : ICartTotalCalculator
    {
        private readonly IDiscountCalculator discountCalculator;

        public CartTotalCalculator(IDiscountCalculator discountCalculator)
        {
            this.discountCalculator = discountCalculator
                ?? throw new ArgumentNullException(nameof(discountCalculator));
        }

        public void CalculateTotal(Cart cart)
        {
            cart.TotalInUsDollarsWithDiscounts = cart.Products
                .Sum(product =>
                {
                    var discountPrice = discountCalculator
                        .CalculateProductDiscountForCustomer(product, cart.Customer);

                    return discountPrice * product.Quantity;
                });
        }
    }
}