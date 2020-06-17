using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        PostBLL bll = new PostBLL();
        // GET: Admin/Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PostList()
        {
            CountDTO countdto = new CountDTO();
            countdto = bll.GetAllCounts();
            ViewData["AllCounts"] = countdto;
            List<PostDTO> postlist = new List<PostDTO>();
            postlist = bll.GetPosts();
            return View(postlist);
        }
        public ActionResult AddPost()
        {
            PostDTO model = new PostDTO();

            model.Categories = CategoryBLL.GetCategoriesForDropdown();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPost(PostDTO model)
        {
            if (model.PostImage[0] == null)
            {
                ViewBag.ProcessState = General.Messages.ImageMissing;
            }
            else if (ModelState.IsValid)
            {

                foreach (var item in model.PostImage)
                {
                    Bitmap image = new Bitmap(item.InputStream);
                    string ext = Path.GetExtension(item.FileName);
                    if (ext != ".png" && ext != ".jpeg" && ext != ".jpg")
                    {
                        ViewBag.ProcessState = General.Messages.ExtensionError;
                        model.Categories = CategoryBLL.GetCategoriesForDropdown();
                        return View(model);
                    }

                }
                List<PostImageDTO> imagelist = new List<PostImageDTO>();
                foreach (var postedfile in model.PostImage)
                {
                    Bitmap image = new Bitmap(postedfile.InputStream);
                    Bitmap resizeimage = new Bitmap(image, 750, 422);
                    string filename = "";
                    string uniqueNumber = Guid.NewGuid().ToString();
                    filename = uniqueNumber + postedfile.FileName;
                    resizeimage.Save(Server.MapPath("~/Areas/Admin/Content/PostImage/" + filename));
                    PostImageDTO dto = new PostImageDTO();
                    dto.ImagePath = filename;
                    imagelist.Add(dto);
                }
                model.PostImages = imagelist;
                if (bll.AddPost(model))
                {
                    ViewBag.ProcessState = General.Messages.AddSuccess;
                    ModelState.Clear();
                    model = new PostDTO();
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;


            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            model.Categories = CategoryBLL.GetCategoriesForDropdown();
            return View(model);
        }
        public ActionResult UpdatePost(int ID)
        {
            PostDTO model = new PostDTO();
            model = bll.GetPostWithID(ID);
            model.Categories = CategoryBLL.GetCategoriesForDropdown();
            model.isUpdate = true;
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdatePost(PostDTO model)
        {
            IEnumerable<SelectListItem> selectlist = CategoryBLL.GetCategoriesForDropdown();
            if (ModelState.IsValid)
            {

                if(model.PostImage[0]!=null)
                {
                    foreach (var item in model.PostImage)
                    {
                        Bitmap image = new Bitmap(item.InputStream);
                        string ext = Path.GetExtension(item.FileName);
                        if (ext != ".png" && ext != ".jpeg" && ext != ".jpg")
                        {
                            ViewBag.ProcessState = General.Messages.ExtensionError;
                            model.Categories = CategoryBLL.GetCategoriesForDropdown();
                            return View(model);
                        }

                    }
                    List<PostImageDTO> imagelist = new List<PostImageDTO>();
                    foreach (var postedfile in model.PostImage)
                    {
                        Bitmap image = new Bitmap(postedfile.InputStream);
                        Bitmap resizeimage = new Bitmap(image, 750, 422);
                        string filename = "";
                        string uniqueNumber = Guid.NewGuid().ToString();
                        filename = uniqueNumber + postedfile.FileName;
                        resizeimage.Save(Server.MapPath("~/Areas/Admin/Content/PostImage/" + filename));
                        PostImageDTO dto = new PostImageDTO();
                        dto.ImagePath = filename;
                        imagelist.Add(dto);
                    }
                    model.PostImages = imagelist;

                }

                if (bll.UpdatePost(model))
                {
                    ViewBag.ProcessState = General.Messages.UpdateSuccess;
                }
                else
                    ViewBag.ProcessState = General.Messages.GeneralError;

            }
            else
                ViewBag.ProcessState = General.Messages.EmptyArea;
            model = bll.GetPostWithID(model.ID);
            model.Categories = selectlist;
            model.isUpdate = true;
            return View(model);
        }
        public JsonResult DeletePostImage(int ID)
        {
            string imagepath = bll.DeletePostImage(ID);
            if (System.IO.File.Exists(Server.MapPath("~/Areas/Admin/Content/PostImage/" + imagepath)))
            {
                System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Content/PostImage/" + imagepath));
            }
            return Json("");
        }
        
        public JsonResult DeletePost(int ID)
        {
            List<PostImageDTO> imagelist = bll.DeletePost(ID);
            foreach (var item in imagelist)
            {
                if (System.IO.File.Exists(Server.MapPath("~/Areas/Admin/Content/PostImage/" + item.ImagePath)))
                {
                    System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Content/PostImage/" + item.ImagePath));
                }
            }
            return Json("");
        }
      
        public JsonResult GetCounts()
        {
            CountDTO dto = new CountDTO();
            dto = bll.GetCounts();
            return Json(dto, JsonRequestBehavior.AllowGet);
        }
    }
}