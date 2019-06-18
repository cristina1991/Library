using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Library.Data;
using Library.Data.Entities;

namespace Repository.Concrete
{
    public class GenreRepository : IGenreRepository
    {
        private UniLibraryDbContext db;

        public GenreRepository(UniLibraryDbContext db)
        {
            this.db = db;
        }

        public void AddGenre(Genre genre)
        {
            db.Genres.Add(genre);
            Save();
        }

        public void DeleteGenre(Genre genre)
        {
            db.Genres.Remove(genre);
            Save();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return db.Genres.ToList();
        }

        public Genre GetGenreById(int genreId)
        {
            return db.Genres.Where(x => x.Id == genreId).FirstOrDefault();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateGenre(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
            Save();
        }
    }
}
