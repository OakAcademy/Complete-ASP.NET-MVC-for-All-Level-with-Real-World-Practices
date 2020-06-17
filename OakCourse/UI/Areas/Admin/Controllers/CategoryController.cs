using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {

        CategoryBLL bll = new CategoryBLL();
        // GET: Admin/Category
        public ActionResult CategoryList()
        {
            List<CategoryDTO> model = bll.GetCategories();
            return View(model);
        }
        public ActionResult AddCategory()
        {
            CategoryDTO dto = new CategoryDTO();
            return View(dto);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddCategory(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new CategoryDTO();
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;
            return View(model);
        }

        public ActionResult UpdateCategory(int ID)
        {
            CategoryDTO dto = bll.GetCategoryWithID(ID);
            return View(dto);
        }
        [HttpPost]
        public ActionResult UpdateCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateCategory(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;
                
            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;
            return View(model);
        }

        public JsonResult DeleteCategory(int ID)
        {
            List<PostImageDTO> postimagelist = bll.DeleteCategory(ID);
            foreach (var item in postimagelist)
            {
                if (System.IO.File.Exists(Server.MapPath("~/Areas/Admin/Content/PostImage/" + item.ImagePath)))
                {
                    System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Content/PostImage/" + item.ImagePath));
                }
            }
            return Json("");
        }
    }
}