using System;
using System.Collections.Generic;
using System.Reflection;
using Marketplace.Core;
using Marketplace.Core.Discounts;

namespace Marketplace.DiscountDomain
{
    public class DiscountCalculator : IDiscountCalculator
    {
        private readonly IDictionary<Type, Func<DiscountBase, Customer, Product, bool>> typesToApplicabilityPredicates;

        public DiscountCalculator()
        {
            typesToApplicabilityPredicates = new Dictionary<Type, Func<DiscountBase, Customer, Product, bool>>
            {
                { typeof(DiscountBase), DiscountBasePredicate },
                { typeof(BirthdayDiscount), BirthdayDiscountPredicate},
                { typeof(QuantityDiscount), QuantityDiscountPredicate }
            };

        }
        
        public double CalculateProductDiscountForCustomer(Product product, Customer customer)
        {
            var currentPrice = product.BasePriceInUsDollars;

            foreach (var discount in product.Discounts)
            {
                var predicate = typesToApplicabilityPredicates[discount.GetType()];
                if (predicate(discount, customer, product))
                {
                    currentPrice *= discount.Percent / 100;
                }
            }

            return currentPrice;
        }

        private static bool DiscountBasePredicate(DiscountBase discountBase, Customer customer, Product product)
        {         
            return discountBase.IsActive;
        }

        private static bool BirthdayDiscountPredicate(DiscountBase discountBase, Customer customer, Product product)
        {
            var birthdayDiscount = (BirthdayDiscount) discountBase;

            bool DateOfBirthIsDiscountRange()
                => customer.DateOfBirth >= DateTimeOffset.Now - TimeSpan.FromDays(birthdayDiscount.DateRangeInDays)
                   && customer.DateOfBirth <= DateTimeOffset.Now + TimeSpan.FromDays(birthdayDiscount.DateRangeInDays);

            return birthdayDiscount.IsActive && DateOfBirthIsDiscountRange();
        }

        private static bool QuantityDiscountPredicate(DiscountBase discountBase, Customer customer, Product product)
        {
            var quantityDiscount = (QuantityDiscount) discountBase;

            return product.Quantity < quantityDiscount.QuantityWhenDiscountEnables;
        }
    }
}