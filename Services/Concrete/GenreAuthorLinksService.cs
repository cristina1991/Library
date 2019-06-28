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

        public void DeleteGenreAuthorLink(int genreId, int authorId)
        {
            genreAuthorLinkRepo.DeleteGenreAuthorLink(genreId, authorId);
        }

        public ICollection<Author> GetAllAuthorsByGenreId(int genreId)
        {
            return genreAuthorLinkRepo.GetAllAuthorsByGenreId(genreId);
        }

        public ICollection<Genre> GetAllGenresByAuthorId(int authorId)
        {
            return genreAuthorLinkRepo.GetAllGenresByAuthorId(authorId);
        }
    }
}
