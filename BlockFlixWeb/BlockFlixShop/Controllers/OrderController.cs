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
    public class OrderController : Controller
    {
        private IServiceGateway<Customer> _cg = new Facade().GetCustomerGateway();
        private IServiceGateway<Order> _og = new Facade().GetOrderGateway();
        private IServiceGateway<Movie> _mg = new Facade().GetMovieGateway();

        private ShoppingCart GetCart()
        {
            var cart = Session["ShoppingCart"] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session["ShoppingCart"] = cart;
            }
            return cart;
        }


        public ActionResult OrderVerification(string customerEmail)
        {
            var customer = _cg.Get(customerEmail);
            var order = new Order();
            order.Movies = GetCart().GetMovies();
            order.Customer = customer;
            order.DateOfPurchase = DateTime.Now.Date;
            return View(order);
        }

        [HttpGet]
        public ActionResult PlaceOrder(Order order)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult PlaceOrder(int CustomerId)
        {
            var order = new Order();
            var customer = _cg.Get(CustomerId);
            order.Customer = customer;
            order.Movies = ShoppingCart.GetCart().GetMovies();
            order.DateOfPurchase = DateTime.Now;
            _og.Create(order);
            ShoppingCart.EmptyCart();
            return View(order);
        }

        public ActionResult RemoveFromCartVerification(int id, string customerEmail)
        {
            var movie = _mg.Get(id);
            GetCart().RemoveMovie(movie);
            return RedirectToAction("OrderVerification", "Order", new { customerEmail });
        }
    }
}