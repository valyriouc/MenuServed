using System.Net;

namespace Backend.Information;

public struct InformationMessage
{
    public string Content { get; set; }
}

public struct InformationData
{
    public HttpStatusCode StatusCode { get; }

    public IEnumerable<InformationMessage> Messages { get; } 

    public InformationData(HttpStatusCode statusCode) 
        : this(
              statusCode, 
              Enumerable.Empty<InformationMessage>()) { }

    public InformationData(
        HttpStatusCode statusCode, 
        IEnumerable<InformationMessage> messages) 
    { 
        StatusCode = statusCode; 
        Messages = messages;
    }
}
