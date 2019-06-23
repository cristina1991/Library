using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entities
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public string Born { get; set; }
        public string City { get; set; }
        public string ImgPath { get; set; }

        public ICollection<Book> Books { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
