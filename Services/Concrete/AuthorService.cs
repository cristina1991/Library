using Services.Abstract;
using System;
using System.Collections.Generic;
using Library.Data.Entities;
using Repository.Abstract;

namespace Services.Concrete
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository authorRepo;

        public AuthorService(IAuthorRepository authorRepo)
        {
            this.authorRepo = authorRepo;
        }

        public void AddAuthor(Author author)
        {
            authorRepo.AddAuthor(author);
        }

        public void DeleteAuthor(Author author)
        {
            authorRepo.DeleteAuthor(author);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return authorRepo.GetAllAuthors();
        }

        public Author GetAuthorById(int authorId)
        {
            return authorRepo.GetAuthorById(authorId);
        }

        public void UpdateAuthor(Author author)
        {
            authorRepo.UpdateAuthor(author);
        }
    }
}
