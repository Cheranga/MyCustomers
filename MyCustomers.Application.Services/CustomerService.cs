using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyCustomers.Application.Dto.Requests;
using MyCustomers.Application.Dto.Responses;
using MyCustomers.Infrastructure.Abstractions.Application.Customers;
using MyCustomers.Infrastructure.Core;

namespace MyCustomers.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGetCustomersHandler _getCustomersHandler;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IGetCustomersHandler getCustomersHandler, ILogger<CustomerService> logger)
        {
            _getCustomersHandler = getCustomersHandler;
            _logger = logger;
        }

        public async Task<OperationResult<GetCustomersResponse>> GetCustomersAsync(GetCustomersRequest request)
        {
            var requestResult = request.Validate();
            if (!requestResult.Status)
            {
                var message = $"Error: Invalid request: {requestResult.Message}";
                _logger.LogError(message);

                return OperationResult<GetCustomersResponse>.Failure(message);
            }

            var getCustomersOperationResult = await _getCustomersHandler.HandleAsync(request).ConfigureAwait(false);

            return getCustomersOperationResult;
        }
    }
}