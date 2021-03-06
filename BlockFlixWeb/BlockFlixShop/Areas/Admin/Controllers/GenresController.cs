﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BlockFlixDLL;
using BlockFlixDLL.Contexts;
using BlockFlixDLL.Entities;

namespace BlockFlixShop.Areas.Admin.Controllers
{
    public class GenresController : Controller
    {
        private readonly IServiceGateway<Genre> _gg = new Facade().GetGenreGateway();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_gg.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _gg.Create(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = _gg.Get(id.Value);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                _gg.Update(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = _gg.Get(id.Value);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre genre = _gg.Get(id);
            _gg.Remove(genre);
            return RedirectToAction("Index");
        }

    }
}
