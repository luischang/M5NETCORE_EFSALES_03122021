using M5NETCORE_EFSALES.CORE.Entities;
using M5NETCORE_EFSALES.CORE.Exceptions;
using M5NETCORE_EFSALES.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5NETCORE_EFSALES.CORE.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                throw new GeneralException("El cliente no existe");
            }
            return customer;
        }

        public async Task<bool> Insert(Customer customer)
        {
            return await _customerRepository.Insert(customer);
        }
        public async Task<bool> Update(Customer customer)
        {
            return await _customerRepository.Update(customer);
        }
        public async Task<bool> Delete(int id)
        {
            return await _customerRepository.Delete(id);
        }

    }
}
