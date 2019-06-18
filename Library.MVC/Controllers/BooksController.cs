using Services.Abstract;
using System.Web.Mvc;
using Library.Data.Entities;

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
    }
}