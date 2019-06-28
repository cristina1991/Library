using Library.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IUserFavouriteService
    {
        void AddUserFavourite(UserFavourites userFavourite);
        ICollection<Book> GetAllFavouritesByUserId(string userId);
    }
}
