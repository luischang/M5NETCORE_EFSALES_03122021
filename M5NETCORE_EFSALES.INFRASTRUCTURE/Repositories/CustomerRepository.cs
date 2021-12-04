using M5NETCORE_EFSALES.CORE.Entities;
using M5NETCORE_EFSALES.CORE.Interfaces;
using M5NETCORE_EFSALES.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5NETCORE_EFSALES.INFRASTRUCTURE.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesDB2021Context _context;

        public CustomerRepository(SalesDB2021Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task<bool> Insert(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            int rows = await _context.SaveChangesAsync();

            return (rows > 0);
        }

        public async Task<bool> Update(Customer customer)
        {
            var customerNow = await _context.Customer.FindAsync(customer.Id);
            if (customerNow==null) return false;
            customerNow.FirstName = customer.FirstName;
            customerNow.LastName = customer.LastName;
            customerNow.Country = customer.Country;
            customerNow.City = customer.City;
            customerNow.Phone = customer.Phone;
            int rows = await _context.SaveChangesAsync();

            return (rows > 0);
        }

        public async Task<bool> Delete(int id)
        {
            var customerNow = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customerNow);
            int rows = await _context.SaveChangesAsync();
            return (rows > 0);
        }
    }
}
