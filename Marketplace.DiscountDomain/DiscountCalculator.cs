using System;
using System.Collections.Generic;
using System.Reflection;
using Marketplace.Core;
using Marketplace.Core.Discounts;

namespace Marketplace.DiscountDomain
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private readonly IDictionary<Type, Func<DiscountBase, Customer, bool>> typesToApplicabilityPredicates;

        public DiscountCalculator()
        {
            typesToApplicabilityPredicates = new Dictionary<Type, Func<DiscountBase, Customer, bool>>
            {
                { typeof(DiscountBase), DiscountBasePredicate },
                { typeof(BirthdayDiscount), BirthdayDiscountPredicate}
            };

        }
        
        public void CalculateProductDiscountForCustomer(Product product, Customer customer)
        {
            var currentPrice = product.BasePriceInUsDollars;

            foreach (var discount in product.Discounts)
            {
                var predicate = typesToApplicabilityPredicates[discount.GetType()];
                if (predicate(discount, customer))
                {
                    currentPrice *= discount.Percent / 100;
                }
            }

            product.DiscountPriceIsUsDollars = currentPrice;
        }

        private static bool DiscountBasePredicate(DiscountBase discountBase, Customer customer)
        {         
            return discountBase.IsActive;
        }

        private static bool BirthdayDiscountPredicate(DiscountBase discountBase, Customer customer)
        {
            var birthdayDiscount = (BirthdayDiscount) discountBase;

            bool DateOfBirthIsDiscountRange()
                => customer.DateOfBirth >= DateTimeOffset.Now - TimeSpan.FromDays(birthdayDiscount.DateRangeInDays)
                   && customer.DateOfBirth <= DateTimeOffset.Now + TimeSpan.FromDays(birthdayDiscount.DateRangeInDays);

            return birthdayDiscount.IsActive && DateOfBirthIsDiscountRange();
        }
    }
}