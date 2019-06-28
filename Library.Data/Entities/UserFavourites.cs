using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class UserFavourites : IEntity
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public string UserId { get; set; }
    }
}
