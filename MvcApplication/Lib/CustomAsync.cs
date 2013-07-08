using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Lib
{
    public class CustomAsync
    {
        public CustomAwaitable DoWork()
        {
            return new CustomAwaitable();
        }
    }
}