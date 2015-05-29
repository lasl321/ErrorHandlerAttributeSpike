using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace ErrorHandlerAttributeSpike.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        [MyActionErrorHandler(typeof(InvalidOperationException), HttpStatusCode.BadRequest)]
        [MyActionErrorHandler(typeof(InvalidCastException), HttpStatusCode.NotFound)]
        public int Get(int id)
        {
            if (id == 111) throw new InvalidOperationException("Invalid operation");
            if (id == 222) throw new InvalidCastException("Invalid cast");
            if (id == 666) throw new Exception("Generic error");

            return id;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    [Serializable]
    public class MyException : Exception
    {
        public MyException(HttpStatusCode statusCode) :
            base(string.Format("Status code: {0}", statusCode))
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; private set; }
    }
}