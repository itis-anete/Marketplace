using System;
using System.Collections.Generic;
using System.Linq;
using MarketPlace.Infrastructure;

namespace MarketPlace.Core
{
    public class Market
    {
        private List<ProductCategory> productsCategories;
        private List<ProductInfo> productInfos;
    
        private Market()
        {
        }

        public Market(string name, List<ProductCategory> initialCategories = null)
        {
            Name = name.CheckValue();
            
            productsCategories = initialCategories ?? new List<ProductCategory>();

            productInfos = new List<ProductInfo>();
        }
        
        public string Name { get; private set; }

        /// <summary>
        /// Оценка магазина
        /// </summary>
        public Point Ball { get; private set; }

        public IEnumerable<ProductCategory> ProductsCategories => productsCategories.AsEnumerable();

        public IEnumerable<ProductInfo> ProductInfos => productInfos.AsEnumerable();

        /// <summary>
        /// Добавить оценку магазину
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(int point)
        {
            Ball.AddPoint(point);
        }
    }
}