using System.ComponentModel.DataAnnotations;

namespace Marketplace.App.DataBase.Entities
{
    public abstract class Identity
    {
        [Key]
        public int Id { get; set; }
    }
}
