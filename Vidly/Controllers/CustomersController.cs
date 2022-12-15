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
       
        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer) //Model Binding
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }

            if (customer.id == 0)
             _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c=> c.id == customer.id);
               
                //TryUpdateModel(customerInDb);//1 way to update 

                //2 way
                customerInDb.name = customer.name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

                //3 way - using automapper
                //Mapper.Map(customer, customerInDb);

            }
            _context.SaveChanges(); //Save changes in db
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(u => u.id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
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