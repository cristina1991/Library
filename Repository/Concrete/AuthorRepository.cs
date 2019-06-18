using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Library.Data;
using Library.Data.Entities;

namespace Repository.Concrete
{
    public class AuthorRepository : IAuthorRepository
    {
        private UniLibraryDbContext db;

        public AuthorRepository(UniLibraryDbContext db)
        {
            this.db = db;
        }

        public void AddAuthor(Author author)
        {
            db.Authors.Add(author);
            Save();
        }

        public void DeleteAuthor(Author author)
        {
            db.Authors.Remove(author);
            Save();
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return db.Authors.ToList();
        }

        public Author GetAuthorById(int authorId)
        {
            return db.Authors.Where(x => x.Id == authorId).FirstOrDefault();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            db.Entry(author).State = EntityState.Modified;
            Save();
        }
    }
}
