using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyCustomers.Infrastructure.Core;
using MyCustomers.Infrastructure.DataAccess.Models;

namespace MyCustomers.Infrastructure.Abstractions.DataAccess.Repositories
{
    public interface ICustomerRepository
    {
        Task<OperationResult<bool>> CreateCustomerAsync(Customer customer);
        Task<OperationResult<bool>> UpdateCustomerAsync(Customer customer);
        Task<OperationResult<bool>> DeleteCustomerAsync(int id);
        Task<OperationResult<List<Customer>>> GetCustomersAsync(PageModel pageModel);
    }
}
