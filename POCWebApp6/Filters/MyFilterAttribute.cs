using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POCWebApp6.Filters {
public class MyFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
            
            int page = 1;
            int pageSize = 10; 
            if (filterContext.HttpContext.Request.QueryString["page"] != null)
            {
                int.TryParse(filterContext.HttpContext.Request.QueryString["page"], out page);
            }

            if (filterContext.HttpContext.Request.QueryString["pageSize"] != null)
            {
                int.TryParse(filterContext.HttpContext.Request.QueryString["pageSize"], out pageSize);
            }

            filterContext.Controller.ViewData["Page"] = page;
            filterContext.Controller.ViewData["PageSize"] = pageSize;


            base.OnActionExecuting(filterContext);
    }

    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        
        base.OnActionExecuted(filterContext);
    }
}
}