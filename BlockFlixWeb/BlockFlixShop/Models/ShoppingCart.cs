using BlockFlixDLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockFlixShop.Models
{
    public class ShoppingCart
    {
        private List<Movie> Movies { get; set; }

        public void AddMovie(Movie movie)
        {
            var foundMovie = GetMovies().FirstOrDefault(x => x.ID == movie.ID);
            if (foundMovie == null)
            {
                Movies.Add(movie);
            }
        }

        public void RemoveMovie(Movie movie)
        {
            var foundMovie = GetMovies().FirstOrDefault(x => x.ID == movie.ID);
            if (foundMovie != null)
            {
                Movies.RemoveAll(x => x.ID == foundMovie.ID);
            }
        }

        public static ShoppingCart GetCart()
        {
            var cart = HttpContext.Current.Session["ShoppingCart"] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                HttpContext.Current.Session["ShoppingCart"] = cart;
            }
            return cart;
        }

        public List<Movie> GetMovies()
        {
            if (Movies == null)
            {
                Movies = new List<Movie>();
            }
            return Movies;
        }

        public static void EmptyCart()
        {
            HttpContext.Current.Session["ShoppingCart"] = null;
        }
    }
}