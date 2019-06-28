using Services.Abstract;
using System.Web.Mvc;
using Library.Data.Entities;
using System.Web;
using System.IO;
using System;
using Library.MVC.Properties;
using System.Linq;
using Library.MVC.Utils;
using Microsoft.AspNet.Identity;

namespace UniLibrary.Controllers
{ 
    [Authorize]
    public class BooksController : Controller
    {
        private IBookService bookService;
        private IGenreService genreService;
        private IAuthorService authorService;
        private IAuthorBookLinksService authorBookLinksService;
        private IGenreBookLinksService genreBookLinksService;
        private IGenreAuthorLinksService genreAuthorLinksService;
        private IReviewService reviewService;

        public BooksController(IBookService bookService, IGenreService genreService, IAuthorService authorService, 
                               IAuthorBookLinksService authorBookLinksService, IGenreBookLinksService genreBookLinksService, 
                               IGenreAuthorLinksService genreAuthorLinksService, IReviewService reviewService)
        {
            this.bookService = bookService;
            this.genreService = genreService;
            this.authorService = authorService;
            this.authorBookLinksService = authorBookLinksService;
            this.genreBookLinksService = genreBookLinksService;
            this.genreAuthorLinksService = genreAuthorLinksService;
            this.reviewService = reviewService;
        }

        // GET: Books
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                if (currentFilter == null) { searchString = ""; }
                else
                {
                    searchString = currentFilter;
                }
            }

            ViewBag.CurrentFilter = searchString;

            var books = bookService.GetBookFilteredList(searchString, searchString, page ?? 1, 18);
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

                //Adding AuthorToBook 
                var authorBookLink = new AuthorBookLink();
                authorBookLink.AuthorId = book.AuthorId;
                authorBookLink.BookId = book.Id;
                authorBookLinksService.AddAuthorBookLink(authorBookLink);

                //Adding GenreToBook 
                var genreBookLink = new GenreBookLink();
                genreBookLink.BookId = book.Id;
                genreBookLink.GenreId = book.GenreId;
                genreBookLinksService.AddGenreBookLink(genreBookLink);

                //Adding GenreToAuthor 
                var genreAuthorLink = new GenreAuthorLink();
                genreAuthorLink.AuthorId = book.AuthorId;
                genreAuthorLink.GenreId = book.GenreId;
                genreAuthorLinksService.AddGenreAuthorLink(genreAuthorLink);

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

        public ActionResult Delete(int bookId)
        {
            var book = bookService.FindBookById(bookId);

            genreBookLinksService.DeleteGenreBookLink(book.GenreId, book.Id);
            genreAuthorLinksService.DeleteGenreAuthorLink(book.GenreId, book.AuthorId);
            authorBookLinksService.DeleteAuthorBookLink(book.AuthorId, book.Id);

            var reviewsList = reviewService.GetAllReviewsByBookId(bookId);
            foreach (var review in reviewsList)
            {
                reviewService.DeleteReview(review);
            }

            bookService.DeleteBook(book);

            return RedirectToAction("Index");
        }

        public ActionResult SingleBook(int bookId)
        {
            var book = bookService.FindBookById(bookId);
            book.Reviews = reviewService.GetAllReviewsByBookId(bookId);
            return View(book);
        }

        public void AddReview(string bookReview, int bookId)
        {
            var review = new Review();
            review.Comment = bookReview;
            review.BookId = bookId;
            reviewService.AddReview(review);
        }

        public void AddFavourite(int bookId)
        {
            var userId = User.Identity.GetUserId();
        }

        public ActionResult AddAuthor(string authorName)
        {
            var author = new Author();
            author.Name = authorName;
            authorService.AddAuthor(author);

            return Json(new { authorId = author.Id });
        }

        public ActionResult AddGenre(string genreName)
        {
            var genre = new Genre();
            genre.Name = genreName;
            genreService.AddGenre(genre);

            return Json(new { genreId = genre.Id });
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