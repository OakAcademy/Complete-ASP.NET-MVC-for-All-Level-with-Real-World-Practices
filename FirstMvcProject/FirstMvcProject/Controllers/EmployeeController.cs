using FirstMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employeelist = new List<Employee>();
            Employee employee = new Employee();
            employee.ID = 1;
            employee.Name = "Charles";
            employee.Salary = 5000;
            employeelist.Add(employee);
            Employee emp2 = new Employee();
            emp2.ID = 2;
            emp2.Name = "Bernard";
            emp2.Salary = 4000;
            employeelist.Add(emp2);
            ViewData["Age"] = 20;
            ViewBag.Job = "Engineer";
            string company2 = "OAK";
            TempData["company"] = company2;
            return View(employeelist);
        }
       public JsonResult GetDateWithJson()
        {
            string JsonDate = DateTime.Today.ToShortDateString();
            return Json(JsonDate);
        }
        public ActionResult AddEmployee()
        {
            Employee emp = new Employee();
            return View(emp);
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            string textvalue = "";
            if (ModelState.IsValid)
                textvalue = "Model State is Valid";
            else
                textvalue = "Model state is not valid";
            return View(employee);
        }
        public ActionResult UpdateEmployee()
        {
            Employee employee = new Employee();
            employee.ID = 1;
            string company = (string)TempData["company"];
            employee.Name = company;
            employee.Salary = 1000;
            return View(employee);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            return View(employee);
        }

    }
}