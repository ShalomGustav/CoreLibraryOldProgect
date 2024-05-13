using System;

namespace CoreLibrary.Exceptions
{
    public class HttpResponceException : Exception
    {
        public HttpResponceException()
        {
        }

        public HttpResponceException(string message):base(message)
        {
        }

        public HttpResponceException(string statusCode, string statusDescription)
        {
            StatusCode = statusCode;
            StatusDescription = statusDescription;
        }

        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
}
