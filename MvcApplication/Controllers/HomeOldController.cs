using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Lib;

namespace MvcApplication.Controllers
{
    [UseStopwatch]
    public class HomeOldController : AsyncController
    {
        public void IndexAsync()
        {
            AsyncManager.OutstandingOperations.Increment(2);
            var request = HttpContext.Request;
            var baseUrl = String.Format("{0}://{1}/api/", request.Url.Scheme, request.Url.Authority);
            var fooClient = new WebClient();
            fooClient.DownloadStringCompleted += (sender, e) =>
            {
                AsyncManager.Parameters["foo"] = e.Result;
                AsyncManager.OutstandingOperations.Decrement();
            };
            fooClient.DownloadStringAsync(new Uri(baseUrl + "foo"));
            var barClient = new WebClient();
            barClient.DownloadStringCompleted += (sender, e) =>
            {
                AsyncManager.Parameters["bar"] = e.Result;
                AsyncManager.OutstandingOperations.Decrement();
            
            };
            barClient.DownloadStringAsync(new Uri(baseUrl + "bar"));
        }

        public ActionResult IndexCompleted(string foo, string bar)
        {
            ViewBag.Text = foo + bar;
            return View("Index");
        }

    }
}
