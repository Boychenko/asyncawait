using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MvcApplication.Lib
{
    public static class CustomeDelay
    {
        public static Task Delay(int millisecondsTimeout)
        {
            var tcs = new TaskCompletionSource<object>();
            var timer = new System.Timers.Timer(millisecondsTimeout) {AutoReset = false};
            timer.Elapsed += delegate
                {
                    timer.Dispose();
                    tcs.SetResult(null);
                };
            timer.Start();
            return tcs.Task;
        }
    }
}