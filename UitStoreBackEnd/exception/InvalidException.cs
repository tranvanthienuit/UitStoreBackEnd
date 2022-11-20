using System.Reflection;
using System.Runtime.Serialization;
using UitStoreBackEnd.base_factory;

namespace UitStoreBackEnd.exception;

[Serializable]
public class InvalidException : CustomAttributeFormatException
{
    private readonly IResponseFactory _responseFactory;

    public InvalidException(IResponseFactory responseFactory)
    {
        _responseFactory = responseFactory;
    }

    protected InvalidException(SerializationInfo info, StreamingContext context, IResponseFactory responseFactory) :
        base(info, context)
    {
        _responseFactory = responseFactory;
    }

    public InvalidException(string? message, IResponseFactory responseFactory) : base(message)
    {
        _responseFactory = responseFactory;
    }

    public InvalidException(string? message, Exception? inner, IResponseFactory responseFactory) : base(message, inner)
    {
        _responseFactory = responseFactory;
    }
}