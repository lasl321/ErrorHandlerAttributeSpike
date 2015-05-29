using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using log4net;

namespace ErrorHandlerAttributeSpike
{
    public class MyActionErrorHandlerAttribute : ExceptionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (MyActionErrorHandlerAttribute));

        private readonly HttpStatusCode _code;
        private readonly Type _exceptionType;

        public MyActionErrorHandlerAttribute(Type exceptionType, HttpStatusCode code)
        {
            Log.DebugFormat("Constructor. Action");

            _exceptionType = exceptionType;
            _code = code;
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            Log.DebugFormat("OnException. Action");

            if (context.Response != null)
            {
                Log.DebugFormat("OnException. Action. NOT Null");
                return;
            }
            else
            {
                Log.DebugFormat("OnException. Action. Null");
            }

            if (_exceptionType != context.Exception.GetType())
            {
                Log.DebugFormat("OnException. Action. NOT Exception");
                return;
            }
            else
            {
                Log.DebugFormat("OnException. Action. exception");
            }

            context.Response = context.Request.CreateResponse(_code, new {context.Exception.Message});
        }
    }
}