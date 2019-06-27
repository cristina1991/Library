using Repository.Abstract;
using System;
using System.Collections.Generic;
using Library.Data.Entities;
using Library.Data;
using System.Linq;

namespace Repository.Concrete
{
    public class GenreBookLinksRepository : IGenreBookLinksRepository
    {
        private UniLibraryDbContext db;

        public GenreBookLinksRepository(UniLibraryDbContext db)
        {
            this.db = db;
        }

        public void AddGenreBookLink(GenreBookLink genreBookLink)
        {
            db.GenreBookLink.Add(genreBookLink);
            Save();
        }

        public IEnumerable<Book> GetAllBooksByGenreId(int genreId)
        {
            return db.GenreBookLink.Where(x => x.GenreId == genreId).Select(x => x.Book).ToList();
        }

        public IEnumerable<Genre> GetAllGenresByBookId(int bookId)
        {
            return db.GenreBookLink.Where(x => x.BookId == bookId).Select(x => x.Genre).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
