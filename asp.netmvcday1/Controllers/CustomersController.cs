using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using asp.netmvcday1.Models;
using System.Data.Entity;
namespace asp.netmvcday1.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        // GET: Customers
       
        private ApplicationDbContext dbContext = null;
        public CustomersController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        //public ActionResult DisplayName()
        //{
        //    Customer customer = new Customer { Id=1,Name = "Young sheldon" };
        //    return View(customer);
        //}
        public ActionResult Details(int id)
        {
            var customer = dbContext.Customers.Include(k => k.MembershipType).ToList().SingleOrDefault(a => a.Id == id);
            return View(customer);
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            var customers = dbContext.Customers.Include(k => k.MembershipType).ToList();
            return View("IndexCustomer", customers);
        }
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>
       {
           new Customer{Id=1,Name="Kd",BirthDate=Convert.ToDateTime("25/02/1998"),Gender="Female"},
           new Customer{Id=2,Name="Ki",BirthDate=Convert.ToDateTime("25/07/1998"),Gender="Male"},
           new Customer{Id=3,Name="Shelly",BirthDate=Convert.ToDateTime("01-01-2019"),Gender="Female"},
           new Customer{Id=4,Name="Kate",BirthDate=Convert.ToDateTime("12/02/2000"),Gender="Female"}
       };
            return customers;
        }
        [HttpGet]
        public ActionResult Create()
        {
            var customer = new Customer();
            ViewBag.gender = GetItems();
            ViewBag.MembershipTypeId = ListMembership();
            return View(customer);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customerFromview)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.gender = GetItems();
                ViewBag.MembershipTypeId = ListMembership();
                return View(customerFromview);
            }
            dbContext.Customers.Add(customerFromview);//Insert operation
            dbContext.SaveChanges();//Update to database
            return RedirectToAction("Index", "Customers");
        }

        public List<SelectListItem> GetItems()
        {
            var gender = new List<SelectListItem>
            {
                new SelectListItem{Text="Select a gender",Value="0",Disabled=true,Selected=true},
                new SelectListItem{Text="Male",Value="Male"},
                   new SelectListItem{Text="Female",Value="Female"},
                      new SelectListItem{Text="Others",Value="Others"}
            };

            return gender;
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customers = dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customers != null)
            {
                ViewBag.gender = GetItems();
                ViewBag.MembershipTypeId = ListMembership();
                return View(customers);
            }
            return HttpNotFound("CustomerId not exist");
        }
        [HttpPost]
        public ActionResult Edit(Customer CustomerFromView)
        {
            if (ModelState.IsValid)
            {
                var customerInDB = dbContext.Customers.FirstOrDefault(c => c.Id == CustomerFromView.Id);
                customerInDB.Name = CustomerFromView.Name;
                customerInDB.City = CustomerFromView.City;
                customerInDB.Gender = CustomerFromView.Gender;
                customerInDB.BirthDate = CustomerFromView.BirthDate;
                customerInDB.MembershipTypeId = CustomerFromView.MembershipTypeId;

                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
            else
            {
                ViewBag.gender = GetItems();
                ViewBag.MembershipTypeId = ListMembership();
                return View(CustomerFromView);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customers = dbContext.Customers.SingleOrDefault(c => c.Id == id);


            if (customers != null)
            {
              
                return View(customers);
            }
            return HttpNotFound("CustomerId not exist");
        }

        [HttpPost]

        public ActionResult Delete(Customer CustomerFromView)
        {
            var customers = dbContext.Customers.SingleOrDefault(c => c.Id == CustomerFromView.Id);
            dbContext.Customers.Remove(customers);
            dbContext.SaveChanges();
                return RedirectToAction("Index", "Customers");
            
         
        }


        //public ActionResult Create(string textname)

        //    return View();
        //}
        [NonAction]
        public IEnumerable<SelectListItem> ListMembership()
        {
            var membership = (from m in dbContext.MembershipTypes.AsEnumerable()
                              select new SelectListItem
                              {
                                  Text = m.Type,
                                  Value = m.Id.ToString()
                              }).ToList();
            membership.Insert(0, new SelectListItem { Text = "---Select---", Value = "0", Disabled = true, Selected = true });
            return membership;
        }
    }
}