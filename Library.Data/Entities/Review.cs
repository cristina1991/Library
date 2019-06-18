using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Entities
{
    public class Review : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }

        //public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public ApplicationUser User { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
