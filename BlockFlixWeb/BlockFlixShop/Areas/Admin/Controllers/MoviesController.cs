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
        private  IServiceGateway<Movie> _mm = new Facade().GetMovieGateway();
        private  IServiceGateway<Genre> _gm = new Facade().GetGenreGateway();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_mm.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateMovieViewModel()
            {
                Movie = new Movie(),
                Genres = _gm.GetAll(),
            });
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Year,Price,ImageURL,TrailerURL, GenreId")]Movie movie, List<int> GenreId)//[Bind(Include = "ID,Title,Year,Price,ImageURL,TrailerURL")] Movie movie
        {

            if (ModelState.IsValid)
            {
                movie.Genres = new List<Genre>();
                if (GenreId != null)
                {
                    foreach (var i in GenreId)
                    {
                        movie.Genres.Add(_gm.Get(i));
                    }
                }
                _mm.Create(movie);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            {
                var movie = _mm.GetAll().FirstOrDefault(x => x.ID == id);
                if (movie == null) return RedirectToAction("Index");
                return View(new EditMovieViewModel
                {
                    Movie = movie,
                    Genres = _gm.GetAll(),
                    GenreId = movie.Genres.Select(x => x.ID).ToList()
                });
            }

        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Year,Price,ImageURL,TrailerURL, GenreId")]Movie movie, List<int> GenreId)
        {
            if (GenreId != null)
                movie.Genres = _gm.GetAll().Where(dbGenre => GenreId.Any(y => y == dbGenre.ID)).ToList();
            _mm.Update(movie);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _mm.Get(id.Value);
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
            Movie movie = _mm.Get(id);
            _mm.Remove(movie);
            return RedirectToAction("Index");
        }
    }
}
