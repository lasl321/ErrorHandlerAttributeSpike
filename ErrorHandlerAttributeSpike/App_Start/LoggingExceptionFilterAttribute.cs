using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using log4net;
using Microsoft.Ajax.Utilities;

namespace ErrorHandlerAttributeSpike
{
    public class LoggingExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (LoggingExceptionFilterAttribute));
        
        public override void OnException(HttpActionExecutedContext context)
        {
            var builder = new StringBuilder();
            builder.AppendFormat("Exception: {0}", context.Exception);
            builder.AppendLine();
            builder.AppendFormat("Context request: {0}", context.Request);

            Log.Error(builder);
        }
    }
}