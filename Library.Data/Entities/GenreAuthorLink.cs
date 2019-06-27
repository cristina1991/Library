using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class GenreAuthorLink : IEntity
    {
        public int Id { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}
