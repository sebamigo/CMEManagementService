using System.Net;

namespace CMEManagementService.Exceptions
{
    public class ServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public ServiceException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public ServiceException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}