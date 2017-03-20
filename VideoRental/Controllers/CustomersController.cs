using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRental.Models;

namespace VideoRental.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            IEnumerable<Customer> Customers = GetCustomers();

            return View(Customers);
        }

        public ActionResult Details(int Id)
        {
            Customer customer = GetCustomers().SingleOrDefault(c => c.Id == Id);
            return View(customer);
        }


        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> Customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };

            return Customers;
        }

    }
}