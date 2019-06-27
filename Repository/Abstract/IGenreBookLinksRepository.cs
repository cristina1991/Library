using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IGenreBookLinksRepository
    {
        void AddGenreBookLink(GenreBookLink genreBookLink);
        IEnumerable<Genre> GetAllGenresByBookId(int bookId);
        IEnumerable<Book> GetAllBooksByGenreId(int genreId);
        void Save();
    }
}
