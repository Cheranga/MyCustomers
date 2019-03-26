using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MyCustomers.Application.Dto.Models;
using MyCustomers.Application.Dto.Requests;
using MyCustomers.Application.Dto.Responses;
using MyCustomers.Infrastructure.Abstractions.Application.Customers;
using MyCustomers.Infrastructure.Abstractions.DataAccess.Repositories;
using MyCustomers.Infrastructure.Core;

namespace MyCustomers.Application.Services
{
    public class GetCustomersHandler : IGetCustomersHandler
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<GetCustomersHandler> _logger;

        public GetCustomersHandler(ICustomerRepository customerRepository, ILogger<GetCustomersHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<OperationResult<GetCustomersResponse>> HandleAsync(GetCustomersRequest input)
        {
            var result = input.Validate();
            if (!result.Status)
            {
                _logger.LogError($"Error: {result.Message}");
            }

            var getCustomersOperation = await _customerRepository.GetCustomersAsync(new PageModel()).ConfigureAwait(false);
            if (!getCustomersOperation.Status)
            {
                var message = $"Error: Cannot retrieve customers {getCustomersOperation.Message}";
                _logger.LogError(message);

                return OperationResult<GetCustomersResponse>.Failure(message);
            }

            var displayCustomers = getCustomersOperation.Data.Select(x => new DisplayCustomer(x.Id, x.FullName));

            return OperationResult<GetCustomersResponse>.Success(new GetCustomersResponse(displayCustomers));
        }
    }
}