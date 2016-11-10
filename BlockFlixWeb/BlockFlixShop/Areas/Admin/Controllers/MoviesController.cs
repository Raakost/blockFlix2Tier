using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BlockFlixAdmin.Models;
using BlockFlixDLL;
using BlockFlixDLL.Entities;

namespace BlockFlixShop.Areas.Admin.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IServiceGateway<Movie> _mg = new Facade().GetMovieGateway();
        private readonly IServiceGateway<Genre> _gg = new Facade().GetGenreGateway();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_mg.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateMovieViewModel()
            {
                Movie = new Movie(),
                Genres = _gg.GetAll()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Year,Price,ImageURL,TrailerURL, GenreId")]Movie movie, List<int> GenreId)
        {

            if (ModelState.IsValid)
            {
                movie.Genres = new List<Genre>();
                if (GenreId != null)
                {
                    foreach (var i in GenreId)
                    {
                        movie.Genres.Add(_gg.Get(i));
                    }
                }
                _mg.Create(movie);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            {
                var movie = _mg.GetAll().FirstOrDefault(x => x.ID == id);
                if (movie == null) return RedirectToAction("Index");
                return View(new EditMovieViewModel
                {
                    Movie = movie,
                    Genres = _gg.GetAll(),
                    GenreId = movie.Genres.Select(x => x.ID).ToList()
                });
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Year,Price,ImageURL,TrailerURL, GenreId")]Movie movie, List<int> GenreId)
        {
            if (GenreId != null)
                movie.Genres = _gg.GetAll().Where(dbGenre => GenreId.Any(y => y == dbGenre.ID)).ToList();
            _mg.Update(movie);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _mg.Get(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = _mg.Get(id);
            _mg.Remove(movie);
            return RedirectToAction("Index");
        }
    }
}
