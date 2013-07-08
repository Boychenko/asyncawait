using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace MvcApplication.Controllers
{
    public class FooController : ApiController
    {
        public string Get()
        {
            Thread.Sleep(1000);
            return "foo";
        }

    }
}
