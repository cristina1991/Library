using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IUserFavouriteRepository
    {
        void AddUserFavourite(UserFavourites userFavourite);
        ICollection<Book> GetAllFavouritesByUserId(string userId);
        void Save();
    }
}
