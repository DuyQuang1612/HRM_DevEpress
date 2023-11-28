namespace HRM_DevEpress.Infrastructor.Common
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

        // Hàm tạo khi có lỗi
        public static Result ErrorResult(string message)
        {
            return new Result { Success = false, Message = message };
        }

        public static Result<T> ErrorResult<T>(string message)
        {
            return new Result<T> { Success = false, Message = message };
        }

        // Hàm tạo khi có exception
        public static Result ExceptionResult(Exception ex, string? message = null)
        {
            // Có thể log exception ở đây nếu cần
            return new Result { Success = false, Message = message ?? ex.Message };
        }

        public static Result<T> ExceptionResult<T>(Exception ex, string? message = null)
        {
            // Có thể log exception ở đây nếu cần
            return new Result<T> { Success = false, Message = message ?? ex.Message };
        }

        // Hàm tạo khi thành công với dữ liệu
        public static Result SuccessResult(string? message = null)
        {
            return new Result { Success = true, Message = message };
        }

        public static Result<T> SuccessResult<T>(T data, string? message = null)
        {
            return new Result<T> { Success = true, Data = data, Message = message };
        }
    }

    public class Result<T> : Result
    {
        public new T? Data { get; set; }
    }
}
