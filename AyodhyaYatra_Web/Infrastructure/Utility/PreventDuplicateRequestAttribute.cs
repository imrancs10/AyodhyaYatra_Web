using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AyodhyaYatra_Web.Infrastructure.Utility
{
    public class PreventDuplicateRequestAttribute : ActionFilterAttribute
    {
        private static readonly ConcurrentDictionary<string, bool> _submittedTokens = new ConcurrentDictionary<string, bool>();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var token = request["token"];

            if (string.IsNullOrEmpty(token) || !_submittedTokens.TryAdd(token, true))
            {
                filterContext.Result = new HttpStatusCodeResult(400);
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            var token = request["token"];

            if (!string.IsNullOrEmpty(token))
            {
                _submittedTokens.TryRemove(token, out bool _);
            }

            base.OnActionExecuted(filterContext);
        }
    }


    //public interface IExceptionFilter
    //{
    //    void OnException(ExceptionContext filterContext);
    //}
}