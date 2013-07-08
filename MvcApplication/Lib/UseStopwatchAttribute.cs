using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MvcApplication.Lib
{
    public class UseStopwatchAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            filterContext.Controller.ViewData["stopWatch"] = stopWatch;
            filterContext.Controller.ViewBag.stopWatch = stopWatch;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Stopwatch stopWatch = (Stopwatch)filterContext.Controller.ViewBag.stopWatch;
            stopWatch.Stop();

            double et = stopWatch.Elapsed.TotalSeconds;//(stopWatch.Elapsed.Milliseconds / 1000.0);

            filterContext.Controller.ViewBag.elapsedTime = et.ToString();

        }

    }
}