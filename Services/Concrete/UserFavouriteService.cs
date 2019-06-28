using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data.Entities;
using Repository.Abstract;

namespace Services.Concrete
{
    public class UserFavouriteService : IUserFavouriteService
    {
        private IUserFavouriteRepository userFavouriteRepo;

        public UserFavouriteService(IUserFavouriteRepository userFavouriteRepo)
        {
            this.userFavouriteRepo = userFavouriteRepo;
        }

        public void AddUserFavourite(UserFavourites userFavourite)
        {
            userFavouriteRepo.AddUserFavourite(userFavourite);
        }

        public void DeleteUserFavourite(int bookId, string userId)
        {
            userFavouriteRepo.DeleteUserFavourite(bookId, userId);
        }

        public ICollection<Book> GetAllFavouritesByUserId(string userId)
        {
            return userFavouriteRepo.GetAllFavouritesByUserId(userId);
        }
    }
}
