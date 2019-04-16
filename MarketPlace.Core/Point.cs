using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Core
{
    //балл(оценка) которок получил товар или магазин
    public class Point
    {
        public Guid Id { get; private set; }
        /// <summary>
        /// среднее значение 
        /// </summary>
        public int Average { get; private set; }
        /// <summary>
        /// количество голосований
        /// </summary>
        public int Quantity { get; private set; }
        /// <summary>
        /// балл который собрал
        /// </summary>
        public int Ball { get; private set; }

        public Point(int ball)
        {
            Id = Guid.NewGuid();
            Quantity++;
            Ball = +ball;
            Average = Ball / Quantity;
        }
        /// <summary>
        /// Добавляет балл
        /// </summary>
        /// <param name="ball"></param>
        public void AddPoint(int ball)
        {
            Quantity++;
            Ball = +ball;
            Average = Ball / Quantity;
        }
    }
}
