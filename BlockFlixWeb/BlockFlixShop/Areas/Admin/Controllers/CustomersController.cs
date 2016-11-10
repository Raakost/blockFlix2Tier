using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlockFlixDLL;
using BlockFlixDLL.Contexts;
using BlockFlixDLL.Entities;

namespace BlockFlixShop.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IServiceGateway<Customer> _cg = new Facade().GetCustomerGateway();

        [HttpGet]
        public ActionResult Index()
        {
            return View(_cg.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _cg.Get(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _cg.Create(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _cg.Get(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email,Phone")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _cg.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _cg.Get(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = _cg.Get(id);
            _cg.Remove(customer);
            return RedirectToAction("Index");
        }
    }
}
