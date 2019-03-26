using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using MyCustomers.Application.Dto.Requests;
using MyCustomers.Application.Dto.Responses;
using MyCustomers.Infrastructure.Abstractions.Application;
using MyCustomers.Infrastructure.Abstractions.DataAccess;
using MyCustomers.Infrastructure.Core;

namespace MyCustomers.Application.Services
{

    public interface ICustomerService
    {
        Task<OperationResult<GetCustomersResponse>> GetCustomersAsync(GetCustomersRequest request);
    }
}
