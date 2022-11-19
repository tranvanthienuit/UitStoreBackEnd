namespace UitStoreBackEnd.base_factory.response;

public class BaseResponse<T>
{
    public bool success { get; set; }

    public T data { get; set; }
}