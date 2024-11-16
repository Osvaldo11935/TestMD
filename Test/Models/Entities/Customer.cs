using System.Collections.Generic;
using Teste.Models.Entities.Common;
using Teste.Models.Requests;

namespace Teste.Models.Entities
{
    public class Customer : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual IList<Sale> Sales { get; set; }

        #region Construtores

        public Customer() { }
        public Customer(CreateCustomerRequest request)
        {
            Name = request.Name;
            Email = request.Email;
            PhoneNumber = request.PhoneNumber;
            Address = request.Address;
        }

        #endregion

        #region Method

        public void Update(UpdateCustomerRequest request)
        {
            if(!string.IsNullOrEmpty(request.Name))
                Name = request.Name;
            if(!string.IsNullOrEmpty(request.Email))
                Email = request.Email;
            if(!string.IsNullOrEmpty(request.PhoneNumber))
                PhoneNumber = request.PhoneNumber;
            if(!string.IsNullOrEmpty(request.Address))
                Address = request.Address;
        }

        public void AddSale(List<CreateItemsSaleRequest> requests)
        {
            Sales = new List<Sale>();   
            var itemsSales = new List<ItemsSale>();

            var sale = new Sale(Id.Value);

            requests.ForEach(request => {
                request.SaleId = sale.Id.Value;
                itemsSales.Add(new ItemsSale(request));});

            sale.AddItemsSale(itemsSales);

            Sales.Add(sale);
        }

        #endregion
    }
}
