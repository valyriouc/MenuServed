using System.Net;

namespace Backend.Information;

public class ApiException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public ApiException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public static ApiException NotFound(string message="") => 
        new ApiException(HttpStatusCode.NotFound, message);

    public static ApiException BadRequest(string message="") =>
        new ApiException(HttpStatusCode.BadRequest, message);

    public static ApiException Unauthorized(string message="") => 
        new ApiException(HttpStatusCode.Unauthorized, message);
}
