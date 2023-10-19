namespace IbgeAPI.DTOs.Responses;

public class ApiResponse<T>
{
    public  string Message { get; set; } = null!;
    public  T Data { get; set; }
    public  string Error { get; set; } = null!;
}
