using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public class User
    {
        [Key]
        public string UId { get; set; }

        public List<Product> Cart { get; set; }

        public List<MarketProduct> History { get; set; }

        public string Role { get; set; }
    }
}
