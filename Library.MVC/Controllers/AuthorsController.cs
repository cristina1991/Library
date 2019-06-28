using System.Web.Mvc;
using Library.Data.Entities;
using Services.Abstract;
using System.Web;
using System.IO;
using Library.MVC.Utils;
using Library.MVC.Properties;
using System;
using System.Collections.Generic;

namespace Library.MVC.Controllers
{
    [Authorize]
    public class AuthorsController : Controller
    {
        private IAuthorService authorService;
        private IGenreAuthorLinksService genreAuthorLinkService;
        private IAuthorBookLinksService authorBookLinksService;

        public AuthorsController(IAuthorService authorService, IGenreAuthorLinksService genreAuthorLinkService, IAuthorBookLinksService authorBookLinksService)
        {
            this.authorService = authorService;
            this.genreAuthorLinkService = genreAuthorLinkService;
            this.authorBookLinksService = authorBookLinksService;
        }

        // GET: Author
        public ActionResult Index()
        {
            var authors = authorService.GetAllAuthors();
            foreach (var author in authors)
            {
                var genresList = new List<Genre>(); ;
                var initialList = genreAuthorLinkService.GetAllGenresByAuthorId(author.Id);
                foreach (var item in initialList)
                {
                    if (!genresList.Contains(item))
                    {
                        genresList.Add(item);
                    }
                }
                author.Genres = genresList;
            }

            return View(authors);
        }

        public ActionResult Create()
        {
            var author = new Author();
            return View(author);
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                authorService.AddAuthor(author);
                return RedirectToAction("Index");
            }
            else
            {
                return View(author);
            }
        }

        public ActionResult Edit(int authorId)
        {
            var author = authorService.GetAuthorById(authorId);
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                authorService.UpdateAuthor(author);
                return RedirectToAction("Index");
            }
            else
            {
                return View(author);
            }
        }

        public ActionResult Delete(int authorId)
        {
            var author = authorService.GetAuthorById(authorId);
            authorService.DeleteAuthor(author);
            return RedirectToAction("Index");
        }

        public ActionResult GetAuthorBooks(int authorId)
        {
            var author = authorService.GetAuthorById(authorId);
            ViewBag.AuthorHeader = "Carti scrise de " + author.Name + ": ";
            var books = authorBookLinksService.GetBooksByAuthorId(authorId);
            return View(books);
        }

        public ActionResult UploadAuthorPhoto(HttpPostedFileBase[] files, int authorId)
        {
            foreach (HttpPostedFileBase file in files)
            {
                //Verify if the user selected a file
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    fileName = "Author_" + Utilities.AddTimpestampToFileName(fileName);

                    var directory = Settings.Default.Books;
                    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + directory);

                    //See if the location exists
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path = Path.Combine(path, fileName);

                    file.SaveAs(path);

                    //Save in database
                    var author = authorService.GetAuthorById(authorId);
                    author.ImgPath = directory+fileName;
                    authorService.UpdateAuthor(author);

                    return Json(new { success = true });
                }
            }
            return PartialView();
        }
    }
}