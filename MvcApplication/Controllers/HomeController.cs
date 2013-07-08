using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
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
        [AsyncTimeout(2000)]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var request = HttpContext.Request;
            var baseUrl = String.Format("{0}://{1}/api/", request.Url.Scheme, request.Url.Authority);
            var foo = new WebClient().DownloadStringTaskAsync(baseUrl + "foo");
            var bar = new WebClient().DownloadStringTaskAsync(baseUrl + "bar");
            var results = await Task.WhenAll(foo, bar);
            ViewBag.Text = String.Join("", results);
            return View();
        }
    }
}
