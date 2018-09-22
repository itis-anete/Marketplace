using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Models
{
    public class User
    {
        [Key]
        public string UId { get; set; }

        [NotMapped]
        public List<MarketProduct> Cart { get; set; }

        // public List<Orders> History { get; set; }

        public string Role { get; set; }

        // public Address Address { get; set; }
    }
}
