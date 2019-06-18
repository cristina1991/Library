using System;
using System.Collections.Generic;
using Library.Data.Entities;
using Services.Abstract;
using Repository.Abstract;

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

        public void UpdateBook(Book book)
        {
            bookRepo.UpdateBook(book);
        }
    }
}
