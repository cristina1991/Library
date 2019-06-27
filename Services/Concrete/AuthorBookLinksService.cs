using Library.Data.Entities;
using Repository.Abstract;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class AuthorBookLinksService : IAuthorBookLinksService
    {
        private IAuthorBookLinkRepository authorBookLinkRepo;

        public AuthorBookLinksService(IAuthorBookLinkRepository authorBookLinkRepo)
        {
            this.authorBookLinkRepo = authorBookLinkRepo;
        }

        public void AddAuthorBookLink(AuthorBookLink authorBookLink)
        {
            authorBookLinkRepo.AddAuthorBookLink(authorBookLink);
        }

        public IEnumerable<Author> GetAuthorsByBookId(int bookId)
        {
            return authorBookLinkRepo.GetAuthorsByBookId(bookId);
        }

        public IEnumerable<Book> GetBooksByAuthorId(int authorId)
        {
            return authorBookLinkRepo.GetBooksByAuthorId(authorId);
        }
    }
}
