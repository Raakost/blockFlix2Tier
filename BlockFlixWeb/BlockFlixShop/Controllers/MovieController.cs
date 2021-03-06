﻿using System;
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
        private readonly IServiceGateway<Movie> _mg = new Facade().GetMovieGateway();
        private readonly IServiceGateway<Genre> _gg = new Facade().GetGenreGateway();

        [HttpGet]
        public ActionResult Index(int? genreId)
        {
            var movies = _mg.GetAll();

            if (genreId.HasValue)
            {
                movies = movies.Where(x => x.Genres.Any(y => y.ID == genreId)).ToList();
            }
            return View(movies);
        }
        public ActionResult RemoveFromCart(int id)
        {
            var movie = _mg.Get(id);
            GetCart().RemoveMovie(movie);
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult AddToCart(int id)
        {
            var movie = _mg.Get(id);
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
            return PartialView();
        }
        public ActionResult GenreDropdown()
        {
            return PartialView(_gg.GetAll());
        }
    }
}