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

        public double Price { get; private set; }

        public int Count { get { return Count; }set { if (value < 0) { Count = 0; } else Count = value; } }

        public double PriceWhithDiscount {
            get { if (PriceWhithDiscount == 0) { return Price; }return PriceWhithDiscount; }
            set { if (value < 0) { PriceWhithDiscount = 0; } else PriceWhithDiscount = value; } }
        /// <summary>
        /// Оценка продукта
        /// </summary>
        public Point Ball { get; private set; }
        /// <summary>
        /// Свойства продукта
        /// </summary>
        public List<Properties> Properties { get; private set; }
        /// <summary>
        /// Лист скидок
        /// </summary>
        private List<Discount> Discounts { get; set; }
        
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
        /// <summary>
        /// Добавит Новую скидку
        /// </summary>
        /// <param name="discount"></param>
        public void AddDiscount(Discount discount)
        {
            if (Discounts == null) { Discounts = new List<Discount>(); }
            Discounts.Add(discount);
            DiscountCalculation();
        }
        /// <summary>
        /// Удалит скидку из списка скидок
        /// </summary>
        /// <param name="discount"></param>
        public void RemoveDiscount(Discount discount)
        {
            if (Discounts.Contains(discount))
            {
                Discounts.Remove(discount);
                DiscountCalculation();
            }
        }
        /// <summary>
        /// Считает скидку и в поле PriceWhithDiscount записывает выгодную
        /// </summary>
        private void DiscountCalculation()
        {
            double summary = 0; 
            double nosummary=0;
            foreach (var discount in Discounts)
            {
                if (discount.Summed)
                {
                    summary += discount.Percent;
                }
                else nosummary += discount.Percent;
            }
            if (summary > nosummary)
            {
                PriceWhithDiscount = Price - ((Price / 100) * summary);
            }
            else PriceWhithDiscount = Price - ((Price / 100) * nosummary);
        }
    }
}