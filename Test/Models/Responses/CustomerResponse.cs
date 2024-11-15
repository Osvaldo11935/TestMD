using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models.Entities;

namespace Test.Models.Responses
{
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public CustomerResponse(Customer customer)
        {
            if (customer == null) return;

            Id = customer.Id.Value;
            Name = customer.Name;
            Address = customer.Address;
            Email = customer.Email;
            PhoneNumber = customer.PhoneNumber;
        }
    }
}
