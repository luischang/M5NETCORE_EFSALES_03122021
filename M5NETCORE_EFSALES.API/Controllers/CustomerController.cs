using AutoMapper;
using M5NETCORE_EFSALES.CORE.DTOs;
using M5NETCORE_EFSALES.CORE.Entities;
using M5NETCORE_EFSALES.CORE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace M5NETCORE_EFSALES.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Customer")]
        public async Task<IActionResult> Customer()
        {
            var customers = await _customerService.GetCustomers();

            //var customerList = new List<CustomerCountryDTO>();
            //foreach (var item in customers)
            //{
            //    var customer = new CustomerCountryDTO()
            //    {
            //        Id = item.Id,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        Country = item.Country,
            //        //City = item.City,
            //        //Phone = item.Phone
            //    };
            //    customerList.Add(customer);
            //}
            var customerList = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return Ok(customerList);
        }
        //[AllowAnonymous]
        [HttpGet]
        [Route("CustomerById")]
        public async Task<IActionResult> CustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        [HttpPost]
        [Route("PostCustomer")]
        public async Task<IActionResult> PostCustomer(CustomerPostDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerService.Insert(customer);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut]
        [Route("PutCustomer")]
        public async Task<IActionResult> PutCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            var result = await _customerService.Update(customer);
            if (!result)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.Delete(id);
            if (!result)
                return NotFound();
            return Ok(result);
        }
    }
}
