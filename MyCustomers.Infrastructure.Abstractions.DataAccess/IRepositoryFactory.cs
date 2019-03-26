using System;
using System.Collections.Generic;
using System.Text;

namespace MyCustomers.Infrastructure.Abstractions.DataAccess
{
    public interface IRepositoryFactory
    {
        TRepository GetRepository<TRepository>();
    }
}
