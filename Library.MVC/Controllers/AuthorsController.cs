using System.Web.Mvc;
using Library.Data.Entities;
using Services.Abstract;

namespace Library.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        private IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        // GET: Author
        public ActionResult Index()
        {
            var authors = authorService.GetAllAuthors();
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
    }
}