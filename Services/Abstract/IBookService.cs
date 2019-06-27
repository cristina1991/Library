using System.Collections.Generic;
using Library.Data.Entities;
using Services.Models;

namespace Services.Abstract
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        void AddBook(Book book);
        void UpdateBook(Book book);
        Book FindBookById(int bookId);
        void DeleteBook(Book book);
        PaginatedList<Book> GetBookFilteredList(string author, string book, int pageNo, int pageSize);
    }
}
