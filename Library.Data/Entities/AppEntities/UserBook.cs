using System.ComponentModel.DataAnnotations.Schema;

namespace DataContext.Entities
{
    public class UserBook : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
