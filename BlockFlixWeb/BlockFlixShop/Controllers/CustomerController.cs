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
    public class CustomerController : Controller
    {
        private IServiceGateway<Customer> _cg = new Facade().GetCustomerGateway();

        [HttpGet]
        public ActionResult CreateNewCustomer()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateNewCustomer(CreateCustomerViewModel t)
        {
            var newCustomer = _cg.Create(t.Customer);
            return RedirectToAction("OrderVerification", "Order", new { customerEmail = t.Customer.Email });
        }

        [HttpGet]
        public ActionResult CustomerByEmail()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CustomerByEmail(string email)
        {
            var customer = _cg.Get(email);
            if (customer != null)
            {
                return RedirectToAction("OrderVerification", "Order", new { customerEmail = email });
            }
            else
            {
                return RedirectToAction("CreateNewCustomer", "Customer");
            }
        }

    }
}