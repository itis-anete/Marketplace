using System.ComponentModel.DataAnnotations;

namespace Marketplace.Models
{
    public abstract class Identity
    {
        [Key]
        public int Id { get; set; }
    }
}
