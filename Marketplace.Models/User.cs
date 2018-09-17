using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class User
    {
        [Key]
        public string UId { get; set; }

        public List<MarketProduct> Cart { get; set; }

        // public List<Orders> History { get; set; }

        public string Role { get; set; }

        // public Address Address { get; set; }
    }
}
