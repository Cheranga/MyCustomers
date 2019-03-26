using System;

namespace MyCustomers.Infrastructure.Core
{
    public class OperationResult<T> : OperationResult
    {
        public T Data { get; set; }

        public static OperationResult<T> Success(T data)
        {
            return new OperationResult<T>
            {
                Status = true,
                Data = data
            };
        }

        public static OperationResult<T> Failure()
        {
            return new OperationResult<T>
            {
                Status = false
            };
        }

        public static OperationResult<T> Failure(string message)
        {
            return new OperationResult<T>
            {
                Status = false,
                Message = message
            };
        }
    }
}
