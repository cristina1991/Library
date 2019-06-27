using System;
using System.Collections.Generic;
using Library.Data.Entities;
using Services.Abstract;
using Repository.Abstract;
using Services.Models;
using System.Linq;

namespace Services.Concrete
{
    public class BookService : IBookService
    {
        private IBookRepository bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        public void AddBook(Book book)
        {
            bookRepo.AddBook(book);
        }

        public void DeleteBook(Book book)
        {
            bookRepo.DeleteBook(book);
        }

        public Book FindBookById(int bookId)
        {
            return bookRepo.FindBookById(bookId);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return bookRepo.GetAllBooks();
        }

        public PaginatedList<Book> GetBookFilteredList(string author="", string book="", int pageNo=1, int pageSize=18)
        {
            List<Book> books = bookRepo.GetBooksFilteredList(author, book).ToList();
            var paginatedResults = new PaginatedList<Book>(books, pageNo, pageSize);
            return paginatedResults;
        }

        public void UpdateBook(Book book)
        {
            bookRepo.UpdateBook(book);
        }
    }
}
