using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionHandling.Controllers
{
    public class BaseController : Controller
    {
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    base.OnActionExecuting(filterContext);
        //    //Your logic is here...
        //}

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    Exception exception = filterContext.Exception;
        //    try
        //    {
        //        throw exception;
        //    }
        //    catch (Exception e)
        //    {
        //    }

        //    //filterContext.ExceptionHandled = true;

        //    //var Result = this.View("Error", new HandleErrorInfo(exception,
        //    //                    filterContext.RouteData.Values["controller"].ToString(),
        //    //                    filterContext.RouteData.Values["action"].ToString()));
        //    //filterContext.Result = Result;
        //}
    }
}