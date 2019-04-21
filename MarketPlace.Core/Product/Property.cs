using System;
using MarketPlace.Infrastructure;

namespace MarketPlace.Core
{
    public class Property : IEquatable<Property>
    {
        private Property()
        {
        }

        public Property(string name, string value)
        {
            Id = Guid.NewGuid();
            Name = name.CheckValue();
            Value = value.CheckValue();
        }
        
        public Guid Id { get; private set; }
        
        public string Name { get; private set; }
        
        public string Value { get; private set; }

        #region Comparison
        public bool Equals(Property other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) 
                   && string.Equals(Value, other.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Property) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (StringComparer.InvariantCultureIgnoreCase.GetHashCode(Name) * 397) 
                       ^ StringComparer.InvariantCultureIgnoreCase.GetHashCode(Value);
            }
        }
        #endregion
    }
}