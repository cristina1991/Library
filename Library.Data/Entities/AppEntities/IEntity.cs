using System.ComponentModel.DataAnnotations;

namespace DataContext.Entities
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
