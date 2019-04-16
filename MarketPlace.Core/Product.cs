using MarketPlace.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketPlace.Core
{
    public class Product : ICounterpart<Product>
    {
        private List<ProductCategory> associatedCategories;
        
        private Product()
        {
        }

        public Product(string name, string description, IEnumerable<ProductCategory> associatedCategories,List<Properties> properties)
        {
            Id = Guid.NewGuid();
            
            Name = name.CheckValue();
            
            Description = description.CheckValue();

            Properties = properties;

            this.associatedCategories = associatedCategories?.ToList()
                ?? throw new ArgumentNullException(nameof(associatedCategories));
        }
        
        public Guid Id { get; private set; }
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public byte[] Image { get; private set; }
        /// <summary>
        /// Оценка продукта
        /// </summary>
        public Point Ball { get; private set; }
        /// <summary>
        /// Свойства продукта
        /// </summary>
        public List<Properties> Properties { get; private set; }

        public IEnumerable<ProductCategory> AssociatedCategories => associatedCategories;

        double ICounterpart<Product>.GetSimilarityCoefficient(Product other)
        {
            // TODO: Сравнение по категориям и т.д.
            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase)
                ? 1.0
                : 0.0;
        }
        /// <summary>
        /// Добавить оценку продукту
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(int point)
        {
            Ball.AddPoint(point);
        }
    }
}