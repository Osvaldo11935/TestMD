using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Models.Entities;

namespace Test.Models.Responses
{
    public class ReportCustomerResponse
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double TotalAmountSpent { get; set; }

        public ReportCustomerResponse() { }
        public ReportCustomerResponse(Customer customer, double totalAmountSpent)
        {
            if (customer == null) return;

            Name = customer.Name;
            Address = customer.Address;
            Email = customer.Email;
            PhoneNumber = customer.PhoneNumber;
            TotalAmountSpent = totalAmountSpent;


        }
    }
}
