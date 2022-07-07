using MyShop.Domain.Models;
using MyShop.Infrastructure.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyShop.Infrastructure.Repository
{
    public  class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(ShoppingContext context) : base(context)
        {

        }
        public override IEnumerable<Customer> GetAll()
        {
            return base.GetAll().Select(MapToProxy);
        }

        public override Customer Update(Customer entity)
        {
            var customer = _context.Customers.Single(c => c.CustomerId == entity.CustomerId);

            customer.ShippingAddress = entity.ShippingAddress;
            customer.PostalCode = entity.PostalCode;
            customer.Country = entity.Country;
            customer.Name = entity.Name;
            customer.City = entity.City;

            return base.Update(customer);
        }

        private CustomerProxy MapToProxy(Customer customer)
        {
            return new CustomerProxy
            {
                ShippingAddress = customer.ShippingAddress,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Name = customer.Name,
                City = customer.City,
            };
        }
    }
}
