using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Pharell Wiliams"},
                new Customer { Id = 2, Name = "Paul Johnson"}
            };

        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {
            var viewModel = new CustomersViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Customer(int id)
        {
            int index = customers.FindIndex(f => f.Id == id);
            if (index >= 0)
            {
                Customer chosenCustomer = customers.Find(x => x.Id == id);

                return View(chosenCustomer);
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}