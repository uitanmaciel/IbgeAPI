namespace IbgeAPI.DTOs;

public class ApiResult<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public string? Error { get; set; }
}
