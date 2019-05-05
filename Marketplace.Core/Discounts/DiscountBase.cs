using System;

namespace Marketplace.Core.Discounts
{
    public class DiscountBase : IEquatable<DiscountBase>
    {
        protected DiscountBase()
        {
        }

        public DiscountBase(double percent)
        {
            Id = Guid.NewGuid();
            Percent = percent;
        }
     
        public Guid Id { get; private set; }

        private double percent;
        public double Percent
        {
            get => percent;
            private set
            {
                if (value <= 0) percent = 0;
                if (value >= 100) percent = 100;
                percent = value;
            }
        }
        
        public DateTimeOffset EndDate { get; private set; }

        public bool IsActive => EndDate <= DateTimeOffset.Now;

        #region Comparison
        public bool Equals(DiscountBase other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DiscountBase) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        #endregion
    }
}