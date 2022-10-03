using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FormCollectionMVC.Models;

namespace FormCollectionMVC.Controllers
{
    public class HomeController : Controller
    {
        MvcCRUDBEntities db = new MvcCRUDBEntities();
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
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult EmployeeIndex()
        {
            var employee = db.Employees.ToList();
            return View(employee);

            //return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee();
                emp.Name = formCollection["Name"];
                emp.Office = formCollection["Office"];
                emp.Position = formCollection["Position"];
                emp.Salary = Convert.ToInt32(formCollection["Salary"]);
                emp.Age = Convert.ToInt32(formCollection["Age"]);
                //emp.Address = formCollection["Address"];
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("EmployeeIndex");
            }
            return View();
        }

    }
}