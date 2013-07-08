using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MvcApplication.Lib
{
    public class SomeService
    {
        public async Task<string> GetValue()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                return "from async";
            });
        }
    }
}