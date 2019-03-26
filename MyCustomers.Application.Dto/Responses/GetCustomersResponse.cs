using System.Collections.Generic;
using System.Linq;
using MyCustomers.Application.Dto.Models;

namespace MyCustomers.Application.Dto.Responses
{
    public class GetCustomersResponse
    {
        public GetCustomersResponse()
        {
            Customers = new List<DisplayCustomer>();
        }

        public GetCustomersResponse(IEnumerable<DisplayCustomer> customers)
        {
            Customers = customers?.ToList();
        }

        public List<DisplayCustomer> Customers { get;}
    }
}