using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Library.Data;

namespace Repository.Concrete
{
    public class AuthorBookLinkRepository : IAuthorBookLinkRepository
    {
        private UniLibraryDbContext db;

        public AuthorBookLinkRepository(UniLibraryDbContext db)
        {
            this.db = db;
        }

        public void AddAuthorBookLink(AuthorBookLink authorBookLink)
        {
            db.AuthorBookLink.Add(authorBookLink);
            Save();
        }

        public void DeleteAuthorBookLink(int authorId, int bookId)
        {
            var authorBookLink = db.AuthorBookLink.Where(x => x.AuthorId == authorId && x.BookId == bookId).FirstOrDefault();
            if (authorBookLink != null)
            {
                db.AuthorBookLink.Remove(authorBookLink);
                Save();
            }
        }

        public IEnumerable<Author> GetAuthorsByBookId(int bookId)
        {
            return db.AuthorBookLink.Where(x => x.BookId == bookId).Select(x=>x.Author).ToList();
        }

        public IEnumerable<Book> GetBooksByAuthorId(int authorId)
        {
            return db.AuthorBookLink.Where(x => x.AuthorId == authorId).Select(x => x.Book).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
