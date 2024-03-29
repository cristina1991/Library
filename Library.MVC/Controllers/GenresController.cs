﻿using System.Web.Mvc;
using Library.Data.Entities;
using Services.Abstract;
using System.Linq;

namespace Library.MVC.Controllers
{
    [Authorize]
    public class GenresController : Controller
    {
        private IGenreService genreService;
        private IGenreBookLinksService genreBookLinksService;

        public GenresController(IGenreService genreService, IGenreBookLinksService genreBookLinksService)
        {
            this.genreService = genreService;
            this.genreBookLinksService = genreBookLinksService;
        }

        // GET: Genres
        public ActionResult Index()
        {
            var genres = genreService.GetAllGenres().OrderBy(x=>x.Name);
            return View(genres);
        }

        public ActionResult Create()
        {
            var genre = new Genre();
            return View(genre);
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genreService.AddGenre(genre);
                return RedirectToAction("Index");
            }
            else
            {
                return View(genre);
            }
        }

        public ActionResult Edit(int genreId)
        {
            var genre = genreService.GetGenreById(genreId);
            return View(genre);
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genreService.UpdateGenre(genre);
                return RedirectToAction("Index");
            }
            else
            {
                return View(genre);
            }
        }

        [HttpPost]
        public ActionResult Delete(int genreId)
        {
            var genre = genreService.GetGenreById(genreId);
            genreService.DeleteGenre(genre);

            return RedirectToAction("Index");
        }

        public ActionResult GetGenreBooks(int genreId)
        {
            var genre = genreService.GetGenreById(genreId);
            ViewBag.GenreHeader = "Carti care intra in categoria " + genre.Name + ":";
            var books = genreBookLinksService.GetAllBooksByGenreId(genreId);
            return View(books);
        }

    }
}