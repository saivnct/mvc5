using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Giangbb.FormModels;
using Giangbb.Models;
using Giangbb.Utils;
using Giangbb.ViewModels;


namespace Giangbb.Controllers
{
    public class CustomersController : AbstractController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); // we declare data set in IdentityModels.ApplicationDbContext
                                                                                        //Include(c => c.MembershipType) - eager loading -> Loading relative object          

//            SetFlash("Giangdaika", "success");            
        
            ViewBag.Customers = customers;
            return View();
        }

        public ActionResult Del(int? id)
        {
            if (!id.HasValue)
            {      
                return RedirectToAction("Index", "Customers");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return RedirectToAction("Index", "Customers");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Customers");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Customers");
            }

            var membershipTypes = _context.MembershipTypes.ToList();
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var newCustomerViewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes,
                CustomerForm = new CustomerForm
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Address = customer.Address,
                    Birthday = customer.Birthday.HasValue? DateUtils.GetDateStringByFormat(customer.Birthday.Value,DateUtils.FORMAT_BIRTHDAY):"",
                    MembershipTypeId = customer.MembershipTypeId,
                    IsSubscribedToNewLetters = customer.IsSubscribedToNewLetters
                }
            };

            return View("New", newCustomerViewModel);
        }

        //render view with HtmlHelper
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new NewCustomerViewModel {CustomerForm = new CustomerForm(),MembershipTypes = membershipTypes};

            return View(newCustomerViewModel);
        }

        //render view without HtmlHelper
        public ActionResult New2()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new NewCustomerViewModel { CustomerForm = new CustomerForm(), MembershipTypes = membershipTypes };

            return View(newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerForm customerForm)
        {
            if (customerForm == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)    //check submit form is correct or not, base all attribute of obj
            {                
                SetFlash("Wrong submit form!", "danger");
                //                return RedirectToAction("New2", "Customers");
                var membershipTypes = _context.MembershipTypes.ToList();
                var newCustomerViewModel = new NewCustomerViewModel { CustomerForm = customerForm,MembershipTypes = membershipTypes };
                return View("New", newCustomerViewModel);
            }

            Customer customer = new Customer
            {
                Id = customerForm.Id,
                Name = customerForm.Name,
                Address = customerForm.Address,
                IsSubscribedToNewLetters = customerForm.IsSubscribedToNewLetters,
                MembershipTypeId = customerForm.MembershipTypeId,
                Birthday = DateUtils.GetDateFromString(customerForm.Birthday, DateUtils.FORMAT_BIRTHDAY)
            };

            if (customer.Id == 0)
            {
                //create new
                _context.Customers.Add(customer);
            }
            else
            {
                //update
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.Address = customer.Address;
                customerInDb.IsSubscribedToNewLetters = customer.IsSubscribedToNewLetters;
            }


            _context.SaveChanges();


            return RedirectToAction("Index","Customers");
        }


    }
}