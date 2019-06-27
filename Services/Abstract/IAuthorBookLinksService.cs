using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IAuthorBookLinksService
    {
        void AddAuthorBookLink(AuthorBookLink authorBookLink);
        IEnumerable<Book> GetBooksByAuthorId(int authorId);
        IEnumerable<Author> GetAuthorsByBookId(int bookId);
    }
}
