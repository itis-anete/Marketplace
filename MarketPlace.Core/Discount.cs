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
        public double Percent { get { return Percent; }
            set
            {
                if (value > 100) { Percent = 100; }
                else if (value < 0) { Percent = 0; }
                else { Percent = value; }
            } }
        /// <summary>
        /// Суммируется ли скидка 
        /// </summary>
        public bool Summed { get; private set; }//некоторые скидки не суммируется
    }
}
