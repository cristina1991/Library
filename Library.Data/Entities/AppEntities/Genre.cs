using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Entities
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
