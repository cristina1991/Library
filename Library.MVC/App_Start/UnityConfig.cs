using System.Web;
using System.Web.Mvc;
using Library.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Repository.Abstract;
using Repository.Concrete;
using Services.Abstract;
using Services.Concrete;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Library.MVC.Controllers;

namespace Library.MVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IBookService, BookService>();

            container.RegisterType<IGenreRepository, GenreRepository>();
            container.RegisterType<IGenreService, GenreService>();

            container.RegisterType<IAuthorRepository, AuthorRepository>();
            container.RegisterType<IAuthorService, AuthorService>();

            container.RegisterType<IReviewRepository, ReviewRepository>();
            container.RegisterType<IReviewService, ReviewService>();

            //Link Tables
            container.RegisterType<IAuthorBookLinkRepository, AuthorBookLinkRepository>();
            container.RegisterType<IAuthorBookLinksService, AuthorBookLinksService>();

            container.RegisterType<IGenreBookLinksRepository, GenreBookLinksRepository>();
            container.RegisterType<IGenreBookLinksService, GenreBookLinksService>();

            container.RegisterType<IGenreAuthorLinksRepository, GenreAuthorLinksRepository>();
            container.RegisterType<IGenreAuthorLinksService, GenreAuthorLinksService>();

            container.RegisterType<IUserFavouriteRepository, UserFavouriteRepository>();
            container.RegisterType<IUserFavouriteService, UserFavouriteService>();


            container.RegisterType<AccountController>(new InjectionConstructor());

            //container.RegisterType<IAuthenticationManager>(
            //    new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}