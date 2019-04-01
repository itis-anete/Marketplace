using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Core
{
    public class Discount
    {
        public Guid Id { get; private set; }
        /// <summary>
        /// Название скидки
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Сколько процентов скидка
        /// </summary>
        public int Percent { get; private set; }
        /// <summary>
        /// Суммируется скидка 
        /// </summary>
        public bool Summed { get; private set; }//некоторые скидки не суммируется
    }
}
