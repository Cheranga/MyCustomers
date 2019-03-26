using System;
using System.Collections.Generic;
using System.Text;

namespace MyCustomers.Infrastructure.Core
{
    public interface IValidate
    {
        string GetErrors();
    }
}
