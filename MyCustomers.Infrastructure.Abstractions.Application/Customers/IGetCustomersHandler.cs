using MyCustomers.Application.Dto.Requests;
using MyCustomers.Application.Dto.Responses;
using MyCustomers.Infrastructure.Core;

namespace MyCustomers.Infrastructure.Abstractions.Application.Customers
{
    public interface IGetCustomersHandler : IHandler<GetCustomersRequest, OperationResult<GetCustomersResponse>>
    {
    }
}