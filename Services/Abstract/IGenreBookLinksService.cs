using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IGenreBookLinksService
    {
        void AddGenreBookLink(GenreBookLink genreBookLink);
        IEnumerable<Genre> GetAllGenresByBookId(int bookId);
        IEnumerable<Book> GetAllBooksByGenreId(int genreId);
    }
}
