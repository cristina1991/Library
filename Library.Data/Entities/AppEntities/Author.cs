using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Entities
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public string Born { get; set; }
        public string City { get; set; }

        public ICollection<Book> Books { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
