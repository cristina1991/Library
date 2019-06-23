using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Library.Data.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("LibraryDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<GenreBookLink> GenreBookLink { get; set; }
        public DbSet<AuthorBookLink> AuthorBookLink { get; set; }
    }
}
