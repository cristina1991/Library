using Microsoft.AspNet.Identity;
using Services.Abstract;
using System.Web.Mvc;

namespace Library.MVC.Controllers
{
    public class FavouritesController : Controller
    {
        private IUserFavouriteService userFavouriteService;

        public FavouritesController(IUserFavouriteService userFavouriteService)
        {
            this.userFavouriteService = userFavouriteService;
        }

        // GET: Favourites
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var books = userFavouriteService.GetAllFavouritesByUserId(userId);

            return View(books);
        }
    }
}