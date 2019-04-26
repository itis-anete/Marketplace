using System;

namespace Marketplace.Infrastructure
{
    public static class StringExtensions
    {
        public static string CheckValue(this string stringToCheck)
        {
            if (stringToCheck == null)
            {
                throw new ArgumentNullException(nameof(stringToCheck));
            }
            if (string.IsNullOrWhiteSpace(stringToCheck))
            {
                throw new ArgumentException(nameof(stringToCheck));
            }

            return stringToCheck;
        }
    }
}