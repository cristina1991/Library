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
    public class UserFavouriteRepository : IUserFavouriteRepository
    {
        private UniLibraryDbContext db;

        public UserFavouriteRepository(UniLibraryDbContext db)
        {
            this.db = db;
        }

        public void AddUserFavourite(UserFavourites userFavourite)
        {
            db.UserFavourites.Add(userFavourite);
            Save();
        }

        public void DeleteUserFavourite(int bookId, string userId)
        {
            var userFavourite = db.UserFavourites.Where(x => x.BookId == bookId && x.UserId == userId).FirstOrDefault();
            db.UserFavourites.Remove(userFavourite);
            Save();
        }

        public ICollection<Book> GetAllFavouritesByUserId(string userId)
        {
            return db.UserFavourites.Where(x => x.UserId == userId).Select(x=>x.Book).ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
