using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IGenreAuthorLinksService
    {
        void AddGenreAuthorLink(GenreAuthorLink genreAuthorLink);
        IEnumerable<Genre> GetAllGenresByAuthorId(int authorId);
        IEnumerable<Author> GetAllAuthorsByGenreId(int genreId);
    }
}
