using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Lib;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [UseStopwatch]
        public ActionResult Index()
        {
            var request = HttpContext.Request;
            var baseUrl = String.Format("{0}://{1}/api/", request.Url.Scheme, request.Url.Authority);
            var foo = new WebClient().DownloadString(baseUrl + "foo");
            var bar = new WebClient().DownloadString(baseUrl + "bar");
            ViewBag.Text = foo + bar;
            return View();
        }
    }
}
