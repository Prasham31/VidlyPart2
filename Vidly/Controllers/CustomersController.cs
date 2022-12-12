using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //To get data from database
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //Dispose _context
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {           
            //Exrecise 1 
            //var customers = GetCustomers();

            //Data from database
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList(); //Eager Loading

            return View(customers);
        }
       
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer) //Model Binding
        {
            _context.Customers.Add(customer);
            _context.SaveChanges(); //Save changes in db
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Details(int id)
        {
            //Exercise 1
            //var customer = GetCustomers().SingleOrDefault(u => u.id == id);

            //Data from db
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(u => u.id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{id=1,name="Tejal"},
                 new Customer{id=1,name="Prasham"},
                  new Customer{id=1,name="Meetal"}
            };
        }
    }
}