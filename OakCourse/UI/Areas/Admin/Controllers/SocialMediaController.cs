using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class SocialMediaController : BaseController
    {
        SocialMediaBLL bll = new SocialMediaBLL();
        // GET: Admin/SocialMedia
       
        public ActionResult AddSocialMedia()
        {
            SocialMediaDTO model = new SocialMediaDTO();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSocialMedia(SocialMediaDTO model)
        {
            if (model.SocialImage == null)
            {
                ViewBag.ProcessState = General.Messages.ImageMissing;

            }
            else if (ModelState.IsValid)
            {
                HttpPostedFileBase postedfile = model.SocialImage;
                Bitmap SocialMedia = new Bitmap(postedfile.InputStream);
                string ext = Path.GetExtension(postedfile.FileName);
                string filename = "";
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                {
                    string uniquenumber = Guid.NewGuid().ToString();
                    filename = uniquenumber + postedfile.FileName;
                    SocialMedia.Save(Server.MapPath("~/Areas/Admin/Content/SocialMediaImages/" + filename));
                    model.ImagePath = filename;
                    if (bll.AddSocialMedia(model))
                    {
                        ViewBag.ProcessState = General.Messages.AddSuccess;
                        model = new SocialMediaDTO();
                        ModelState.Clear();
                    }
                    else
                        ViewBag.ProcessState = General.Messages.GeneralError;
                }
                else
                    ViewBag.ProcessState = General.Messages.ExtensionError;
            }
            else
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            return View(model);
        }

        public ActionResult SocialMediaList()
        {
            List<SocialMediaDTO> dtolist = new List<SocialMediaDTO>();
            dtolist = bll.GetSocialMedias();
            return View(dtolist);
        }
        public ActionResult UpdateSocialMedia(int ID)
        {
            SocialMediaDTO dto = bll.GetSocialMediaWithID(ID);
            return View(dto);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMediaDTO model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ProcessState = General.Messages.EmptyArea;
            }
            else
            {
                if (model.SocialImage != null)
                {

                    HttpPostedFileBase postedfile = model.SocialImage;
                    Bitmap SocialMedia = new Bitmap(postedfile.InputStream);
                    string ext = Path.GetExtension(postedfile.FileName);
                    string filename = "";
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".gif")
                    {
                        string uniquenumber = Guid.NewGuid().ToString();
                        filename = uniquenumber + postedfile.FileName;
                        SocialMedia.Save(Server.MapPath("~/Areas/Admin/Content/SocialMediaImages/" + filename));
                        model.ImagePath = filename;
                    }

                }
                string oldImagePath = bll.UpdateSocialMedia(model);
                if(model.SocialImage!=null)
                {
                    if(System.IO.File.Exists(Server.MapPath("~/Areas/Admin/Content/SocialMediaImages/"+ oldImagePath)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Content/SocialMediaImages/"+ oldImagePath));
                    }
                }
                ViewBag.ProcessState = General.Messages.UpdateSuccess;


            }
            return View(model);
        }

        public JsonResult DeleteSocialMedia(int ID)
        {
            string imagepath = bll.DeleteSocialMedia(ID);
            if (System.IO.File.Exists(Server.MapPath("~/Areas/Admin/Content/SocialMediaImages/" + imagepath)))
            {
                System.IO.File.Delete(Server.MapPath("~/Areas/Admin/Content/SocialMediaImages/" + imagepath));
            }
            return Json("");
        }
    }
}