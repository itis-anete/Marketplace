using System;
using Marketplace.Core;

namespace Marketplace.ProductDomain
{
    public class ProductSimilarityCalculator : IProductSimilarityCalculator
    {
        public bool AreProductsSame(Product firstProduct, Product secondProduct)
        {
            var firstProductCategories = firstProduct.AssociatedCategories;
            var secondProductCategories = secondProduct.AssociatedCategories;

            //TODO: Сравнение по категориям.
            return firstProduct.Name.Equals(secondProduct.Name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}