using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class Identity
    {
        [Key]
        public int Id { get; set; }
    }
}
