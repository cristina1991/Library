using Services.Abstract;
using System;
using System.Collections.Generic;
using Library.Data.Entities;
using Repository.Abstract;

namespace Services.Concrete
{
    public class GenreService : IGenreService
    {
        private IGenreRepository genreRepo;

        public GenreService(IGenreRepository genreRepo)
        {
            this.genreRepo = genreRepo;
        }

        public void AddGenre(Genre genre)
        {
            genreRepo.AddGenre(genre);
        }

        public void DeleteGenre(Genre genre)
        {
            genreRepo.DeleteGenre(genre);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return genreRepo.GetAllGenres();
        }

        public Genre GetGenreById(int genreId)
        {
            return genreRepo.GetGenreById(genreId);
        }

        public void UpdateGenre(Genre genre)
        {
            genreRepo.UpdateGenre(genre);
        }
    }
}
