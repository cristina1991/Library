using Services.Abstract;
using System.Web.Mvc;
using Library.Data.Entities;
using System.Web;
using System.IO;
using System;
using Library.MVC.Properties;
using System.Linq;
using Library.MVC.Utils;

namespace UniLibrary.Controllers
{ 
    public class BooksController : Controller
    {
        private IBookService bookService;
        private IGenreService genreService;
        private IAuthorService authorService;

        public BooksController(IBookService bookService, IGenreService genreService, IAuthorService authorService)
        {
            this.bookService = bookService;
            this.genreService = genreService;
            this.authorService = authorService;
        }
        // GET: Books
        public ActionResult Index()
        {
            var books = bookService.GetAllBooks();
            return View(books);
        }

        public ActionResult Create()
        {
            var book = new Book();

            ViewBag.Genres = genreService.GetAllGenres();
            ViewBag.Authors = authorService.GetAllAuthors();

            return View(book);
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.AddBook(book);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Genres = genreService.GetAllGenres();
                ViewBag.Authors = authorService.GetAllAuthors();
                return View(book);
            }
        }

        public ActionResult Edit(int bookId)
        {
            var book = bookService.FindBookById(bookId);

            ViewBag.Genres = genreService.GetAllGenres();
            ViewBag.Authors = authorService.GetAllAuthors();

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                bookService.UpdateBook(book);
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        [HttpPost]
        public ActionResult Delete(int bookId)
        {
            var book = bookService.FindBookById(bookId);
            bookService.DeleteBook(book);

            return RedirectToAction("Index");
        }

        public ActionResult SingleBook(int bookId)
        {
            var book = bookService.FindBookById(bookId);
            return View(book);
        }

        public ActionResult UploadBookPhoto(HttpPostedFileBase[] files, int bookId)
        {
            foreach (HttpPostedFileBase file in files)
            {
                //Verify if the user selected a file
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    fileName = "Book_" + Utilities.AddTimpestampToFileName(fileName);

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
                    var book = bookService.FindBookById(bookId);
                    book.ImgPath = directory+fileName;
                    bookService.UpdateBook(book);

                    return Json(new { success = true });
                }
            }
            return PartialView();
        }

    }
}