using System;
using System.Runtime.Serialization;

namespace MarketPlace.Infrastructure
{
    [Serializable]
    public class MarketNotFoundException : Exception
    {
        public MarketNotFoundException()
        {
        }

        public MarketNotFoundException(string message) : base(message)
        {
        }

        public MarketNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected MarketNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}