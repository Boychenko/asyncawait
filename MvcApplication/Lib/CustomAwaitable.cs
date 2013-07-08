using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;

namespace MvcApplication.Lib
{
    public class CustomAwaitable : INotifyCompletion
    {
        public CustomAwaitable GetAwaiter()
        {
            return this;
        }
        public bool IsCompleted
        {
            get
            {
                return true;
            }
        }
        public void OnCompleted(Action continuation)
        {
            var ctx = SynchronizationContext.Current;
            var t = new Timer(
                delegate
                {
                    ctx.Post(state => continuation(), null);
                }, null, 5000, -1);
        }
        public string GetResult()
        {
            return "foo";
        }
    }
}