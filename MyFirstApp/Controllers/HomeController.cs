using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        } 

        public ActionResult Products()
        {
            return View("OurCompanyProducts");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult GetEmpName(int Empid)
        {
            var employees = new[] {
            new {Empid = 1, EmpName = "Scott", Salary = 8000},
            new {Empid = 2, EmpName = "Smith", Salary = 2540},
            new {Empid = 3, EmpName = "Allen", Salary = 9400}
            };
            string matchEmpName = null;
            foreach (var item in employees)
            {
                if(item.Empid == Empid)
                {
                    matchEmpName = item.EmpName;
                }
            }
            //return new ContentResult() { Content = matchEmpName, ContentType = "text/plain"};
            return Content(matchEmpName, "text/plain");
        }  

        public ActionResult GetPaySlip(int Empid)
        {
            string fileName = "~/PaySlip" + Empid + ".pdf";
            return File(fileName, "application/pdf");
        }

        public ActionResult EmpFacebookPage(int Empid)
        {
            var employees = new[] {
            new {Empid = 1, EmpName = "Scott", Salary = 8000},
            new {Empid = 2, EmpName = "Smith", Salary = 2540},
            new {Empid = 3, EmpName = "Allen", Salary = 9400}
            };

            string fbUrl = null;
            foreach (var item in employees)
            {
                if (item.Empid == Empid)
                {
                    fbUrl = "http://www.facebook.com/emp" + Empid;
                }
            }
            if(fbUrl == null)
            {
                return Content("Invalid emp ID");
            }
            else
            {
                return Redirect(fbUrl);
            }
        }

        public ActionResult StudentDetails()
        {
            ViewBag.StudentId = 101;
            ViewBag.StudentName = "Scott";
            ViewBag.Marks = 50;
            ViewBag.NoOfSemesters = 6;
            ViewBag.Subjects = new List<string>() { "Maths", "Physics", "Chemstry" };

            return View();
        }

        public ActionResult RequestExample()
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalApplicationPath = Request.PhysicalApplicationPath;
            ViewBag.Path = Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString["n"];
            ViewBag.Headers = Request.Headers["Accept"];
            ViewBag.HttpMethod = Request.HttpMethod;
            return View();
        }
    }
}