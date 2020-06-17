using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(string Title)
        {
            return View();
        }
        public ActionResult Detail(string Title,string DetailName)
        {
            return View();
        }
    }
}