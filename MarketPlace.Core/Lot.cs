using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Core
{
    /// <summary>
    /// Лот это товар аукциона
    /// </summary>
    public class Lot
    {
        /// <summary>
        /// товар аукциона
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// начальная цена
        /// </summary>
        public double StartPrice { get; set; }
        /// <summary>
        /// дата оканчание аукциона для товара
        /// </summary>
        public DateTime ExpirationTime { get; set; }
        /// <summary>
        /// Нынешная цена
        /// </summary>
        public double PresentPrise { get; set; }
        /// <summary>
        /// Нынешний покупаталь
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// сделать ставку на товар
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="price"></param>
        public void AddPrice(Customer customer,double price)
        {
            if (price > PresentPrise)
            {
                Customer = customer;
                PresentPrise = price;
            }
        }
    }
}
