using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IGenreAuthorLinksRepository
    {
        void AddGenreAuthorLink(GenreAuthorLink genreAuthorLink);
        void DeleteGenreAuthorLink(int genreId, int authorId);
        ICollection<Genre> GetAllGenresByAuthorId(int authorId);
        ICollection<Author> GetAllAuthorsByGenreId(int genreId);
        void Save();
    }
}
