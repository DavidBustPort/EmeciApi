namespace Application.Common.Wrappers
{
    public class Result<T>
    {
        public T? Data { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = [];

        public static Result<T> Success(T data, string message = "") =>
            new()
            { Succeeded = true, Data = data, Message = message };

        public static Result<T> Failure(List<string> errors, string message = "") =>
            new()
            { Succeeded = false, Errors = errors, Message = message };
    }
}
