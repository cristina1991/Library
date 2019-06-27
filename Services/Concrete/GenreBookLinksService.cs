using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Repository.Abstract;

namespace Services.Concrete
{
    public class GenreBookLinksService : IGenreBookLinksService
    {
        private IGenreBookLinksRepository genreBookLinksRepo;

        public GenreBookLinksService(IGenreBookLinksRepository genreBookLinksRepo)
        {
            this.genreBookLinksRepo = genreBookLinksRepo;
        }

        public void AddGenreBookLink(GenreBookLink genreBookLink)
        {
            genreBookLinksRepo.AddGenreBookLink(genreBookLink);
        }

        public IEnumerable<Book> GetAllBooksByGenreId(int genreId)
        {
            return genreBookLinksRepo.GetAllBooksByGenreId(genreId);
        }

        public IEnumerable<Genre> GetAllGenresByBookId(int bookId)
        {
            return genreBookLinksRepo.GetAllGenresByBookId(bookId);
        }
    }
}
