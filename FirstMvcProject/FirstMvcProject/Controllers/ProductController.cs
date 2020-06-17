using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMvcProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult AddProduct()
        {
            return View();
        }
        public ActionResult UpdateProduct(int ID)
        {
            return View();
        }
    }
}