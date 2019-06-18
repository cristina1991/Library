
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;

namespace Repository.Abstract
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        void AddBook(Book book);
        void UpdateBook(Book book);
        Book FindBookById(int bookId);
        void DeleteBook(Book book);
        void Save();
    }
}
