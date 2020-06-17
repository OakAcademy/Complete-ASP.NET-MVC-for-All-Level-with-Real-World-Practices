using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Models.Attiributes
{
    public class LoginControl : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserStatic.UserID==0)
                filterContext.HttpContext.Response.Redirect("/Admin/Login/Index");
        }
    }
}