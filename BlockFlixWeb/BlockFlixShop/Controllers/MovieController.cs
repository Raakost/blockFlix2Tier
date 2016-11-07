using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlockFlixDLL;
using BlockFlixDLL.Entities;
using BlockFlixShop.Models;

namespace BlockFlixShop.Controllers
{
    public class MovieController : Controller
    {
        private IServiceGateway<Movie> _mm = new Facade().GetMovieManager();
        private IServiceGateway<Genre> _gm = new Facade().GetGenreManager();

        // GET: Movie
        public ActionResult Index(int? genreId)
        {
            var movies = _mm.GetAll();

            if (genreId.HasValue)
            {
                movies = movies.Where(x => x.Genres.Any(y => y.ID == genreId)).ToList();
            }
            return View(movies);
        }
        public ActionResult RemoveFromCart(int id)
        {
            var movie = _mm.Get(id);
            GetCart().RemoveMovie(movie);
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult AddToCart(int id)
        {
            var movie = _mm.Get(id);
            var cart = GetCart();
            cart.AddMovie(movie);

            return RedirectToAction("Index", "Movie");
        }
        public ShoppingCart GetCart()
        {
            var cart = Session["ShoppingCart"] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session["ShoppingCart"] = cart;
            }
            return cart;
        }

        public ActionResult CartDropdown()
        {
            return PartialView(/*GetCart()*/);
        }
        public ActionResult GenreDropdown()
        {
            return PartialView(_gm.GetAll());
        }
    }
}