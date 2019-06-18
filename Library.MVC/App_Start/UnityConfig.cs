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

            container.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}