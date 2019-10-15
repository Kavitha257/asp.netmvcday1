using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp.netmvcday1.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact page.";

            return View();
        }
        public ActionResult Example()
        {
            return View("About");
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Qwerty()
        {
            return View();
        }
        [Route("Searchbyemployee/{empid}/{name}")]
        public ActionResult Edit(int empid,string name)
        {
            if(empid>0)
            {
                return Content("ID" + empid+" "+"name"+name);
            }
            else
            {
                return Content("Id value cannot be negative");
            }

   
     
        }
        [Route("Searchbyproductname/{name}")]
        public ActionResult Products(string name)
        {
            return Content("Product name:" + name);
        }
    }
}