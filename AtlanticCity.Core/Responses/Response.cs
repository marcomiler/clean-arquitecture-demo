using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.Responses
{
    public class Response
    {
        public Response()
        {

        }
        public Response(object result, string message )
        {
            this.Success = false;
            this.Message = message;
            this.Result = result;
        }

        public Response(object result, bool success)
        {
            this.Success = success;
            this.Message = string.Empty;
            this.Result = result;
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

    }
}
