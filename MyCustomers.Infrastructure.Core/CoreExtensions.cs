namespace MyCustomers.Infrastructure.Core
{
    public static class CoreExtensions
    {
        public static OperationResult Validate(this IValidate validatable)
        {
            if (validatable == null)
            {
                return new OperationResult
                {
                    Status = false,
                    Message = "The object is null"
                };
            }

            var errorMessage = validatable.GetErrors();

            return new OperationResult
            {
                Status = string.IsNullOrEmpty(errorMessage),
                Message = errorMessage
            };
        }
    }
}