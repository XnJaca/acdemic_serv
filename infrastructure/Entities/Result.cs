namespace infrastructure.Entities;

public class Result<T>
{
    public T? Data { get; set; }
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }

    public static Result<T> Success(T data) => new() { Data = data, IsSuccess = true };
    public static Result<T> Failure(string errorMessage) => new() { IsSuccess = false, ErrorMessage = errorMessage };
}