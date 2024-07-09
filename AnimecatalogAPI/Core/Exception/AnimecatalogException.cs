using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace AnimecatalogAPI.Core.Exception
{
    public class AnimecatalogException : System.Exception
    {
        public HttpStatusCode? HttpStatusCode { get; set; }

        public AnimecatalogException(string message) : base(message)
        {
        }

        public AnimecatalogException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public AnimecatalogException(string message, HttpStatusCode statusCode) : base(message)
        {
            HttpStatusCode = statusCode;
        }
    }
}
