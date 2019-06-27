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
    public class GenreAuthorLinksService : IGenreAuthorLinksService
    {
        private IGenreAuthorLinksRepository genreAuthorLinkRepo;

        public GenreAuthorLinksService(IGenreAuthorLinksRepository genreAuthorLinkRepo)
        {
            this.genreAuthorLinkRepo = genreAuthorLinkRepo;
        }

        public void AddGenreAuthorLink(GenreAuthorLink genreAuthorLink)
        {
            genreAuthorLinkRepo.AddGenreAuthorLink(genreAuthorLink);
        }

        public IEnumerable<Author> GetAllAuthorsByGenreId(int genreId)
        {
            return genreAuthorLinkRepo.GetAllAuthorsByGenreId(genreId);
        }

        public IEnumerable<Genre> GetAllGenresByAuthorId(int authorId)
        {
            return genreAuthorLinkRepo.GetAllGenresByAuthorId(authorId);
        }
    }
}
