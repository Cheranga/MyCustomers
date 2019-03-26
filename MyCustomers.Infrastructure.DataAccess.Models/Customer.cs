using System;
using System.Collections.Generic;
using System.Text;

namespace MyCustomers.Infrastructure.DataAccess.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
