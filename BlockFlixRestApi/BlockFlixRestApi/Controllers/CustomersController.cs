using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BlockFlixDLL;
using BlockFlixDLL.Contexts;
using BlockFlixDLL.Entities;

namespace BlockFlixRestApi.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly IRepository<Customer> _cr = new Facade().GetCustomerRepository();

        [HttpGet]
        public List<Customer> GetCustomers()
        {
            return _cr.GetAll();
        }

        [HttpGet]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = _cr.Get(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _cr.Update(customer);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _cr.Create(customer);
            return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
        }

        [HttpDelete]
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = _cr.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            _cr.Remove(customer);
            return Ok(customer);
        }
    }
}