using Repository.Abstract;
using System;
using System.Collections.Generic;
using Library.Data.Entities;
using Library.Data;
using System.Linq;

namespace Repository.Concrete
{
    public class GenreAuthorLinksRepository : IGenreAuthorLinksRepository
    {
        private UniLibraryDbContext db;

        public GenreAuthorLinksRepository(UniLibraryDbContext db)
        {
            this.db = db;
        }

        public void AddGenreAuthorLink(GenreAuthorLink genreAuthorLink)
        {
            db.GenreAuthorLink.Add(genreAuthorLink);
            Save();
        }

        public ICollection<Author> GetAllAuthorsByGenreId(int genreId)
        {
            return db.GenreAuthorLink.Where(x => x.GenreId == genreId).Select(x => x.Author).ToList();
        }

        public ICollection<Genre> GetAllGenresByAuthorId(int authorId)
        {
            return db.GenreAuthorLink.Where(x => x.AuthorId == authorId).Select(x => x.Genre).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
