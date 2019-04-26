using Marketplace.Infrastructure;
using System;

namespace Marketplace.Core
{
    public class Address : IEquatable<Address>
    {
        private Address(string index, string country, string city, 
            string street, string building, string apartment)
        {
            Id = Guid.NewGuid();
            
            Index = index.CheckValue();
            Country = country.CheckValue();
            City = city.CheckValue();
            Street = street.CheckValue();
            Building = building.CheckValue();
            Apartment = apartment.CheckValue();
        }
        
        public Guid Id { get; private set; }
        
        public string Index { get; private set; }
        
        public string Country { get; private set; }
        
        public string City { get; private set; }
        
        public string Street { get; private set; }
        
        public string Building { get; private set; }
        
        public string Apartment { get; private set; }

        #region Comparison
        public bool Equals(Address other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Index, other.Index, StringComparison.InvariantCultureIgnoreCase) 
                   && string.Equals(Country, other.Country, StringComparison.InvariantCultureIgnoreCase) 
                   && string.Equals(City, other.City, StringComparison.InvariantCultureIgnoreCase) 
                   && string.Equals(Street, other.Street, StringComparison.InvariantCultureIgnoreCase) 
                   && string.Equals(Building, other.Building, StringComparison.InvariantCultureIgnoreCase) 
                   && string.Equals(Apartment, other.Apartment, StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Address) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = StringComparer.InvariantCultureIgnoreCase.GetHashCode(Index);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCultureIgnoreCase.GetHashCode(Country);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCultureIgnoreCase.GetHashCode(City);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCultureIgnoreCase.GetHashCode(Street);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCultureIgnoreCase.GetHashCode(Building);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCultureIgnoreCase.GetHashCode(Apartment);
                return hashCode;
            }
        }
        #endregion
    }
}