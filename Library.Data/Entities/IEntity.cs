using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
