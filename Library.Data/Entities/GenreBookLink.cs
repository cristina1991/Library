using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class GenreBookLink : IEntity
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
