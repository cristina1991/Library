
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;

namespace Services.Abstract
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
        void AddGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(Genre genre);
        Genre GetGenreById(int genreId);
    }
}
