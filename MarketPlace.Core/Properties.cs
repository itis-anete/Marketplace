using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Core
{
    //клас свойства для товара например:name=вес value=4,7 кг
    public class Properties
    {
        public Properties(string name,string value)
        {
            Id = Guid.NewGuid();
            Name = name;
            Value = value;
        }
        public Guid Id { get; private set; }
        /// <summary>
        /// Название свойства
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Значение свойства
        /// </summary>
        public string Value { get; private set; }
    }
}
