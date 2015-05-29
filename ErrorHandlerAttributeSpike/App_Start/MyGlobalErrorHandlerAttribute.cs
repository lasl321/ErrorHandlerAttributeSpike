using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using log4net;

namespace ErrorHandlerAttributeSpike
{
    public class MyGlobalErrorHandlerAttribute : ExceptionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (MyGlobalErrorHandlerAttribute));

        public MyGlobalErrorHandlerAttribute()
        {
            Log.DebugFormat("Constructor. Global");
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            Log.DebugFormat("OnException. Global");

            if (context.Response == null)
            {
                Log.DebugFormat("OnException. Global. Null");

                context.Response = context.Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    new {context.Exception.Message});
            }
            else
            {
                Log.DebugFormat("OnException. Global. NOT null");
            }
        }
    }
}