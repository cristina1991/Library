using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class AuthorBookLink : IEntity
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Genre Genre { get; set; }
    }
}
