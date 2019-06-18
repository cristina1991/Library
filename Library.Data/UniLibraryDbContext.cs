using System.Data.Entity;
using Library.Data.Entities;
using Library.Data.Entities.UserEntities;

namespace Library.Data
{
    public class UniLibraryDbContext : DbContext
    {
        public UniLibraryDbContext() : base("name=UniversityDb")
        {   }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<GenreBookLink> GenreBookLink { get; set; }
        public DbSet<AuthorBookLink> AuthorBookLink { get; set; }
    }
}
