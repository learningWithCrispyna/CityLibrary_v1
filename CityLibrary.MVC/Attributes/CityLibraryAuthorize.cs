using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CityLibrary.MVC.Attributes
{
    public class CityLibraryAuthorize : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["UserName"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    ["Controller"] = "Account",
                    ["Action"] = "Login"
                });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}