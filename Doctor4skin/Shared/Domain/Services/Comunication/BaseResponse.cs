namespace Doctor4skin.Shared.Domain.Services.Comunication;

public abstract class BaseResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Resource { get; set; }
    protected BaseResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default!;
    }
    protected BaseResponse(T resource)
    {
        Success = true;
        Resource = resource;
        Message = string.Empty;
    }
}
