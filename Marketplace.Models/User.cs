using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Marketplace.Models.ProductData;

namespace Marketplace.Models
{
    public class User
    {
        [Key]
        public string UId { get; set; }

        [NotMapped]
        public List<ProductOffer> Cart { get; set; }

        // public List<Orders> History { get; set; }

        public string Role { get; set; }

        // public Address Address { get; set; }
    }
}
