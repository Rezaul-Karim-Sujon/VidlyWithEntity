﻿using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyWithEntity.App_Start;
using VidlyWithEntity.Dtos;
using VidlyWithEntity.Models;

namespace VidlyWithEntity.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        private MapperConfiguration config;
        private IMapper iMapper;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
            config = new AutoMapperConfiguration().Configure();
            iMapper = config.CreateMapper();
        }
        // GET/api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos= _context.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .Select(iMapper.Map<Customer, CustomerDto>);
            return Ok(customerDtos);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(iMapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = iMapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
            iMapper.Map(customerDto, customerInDb);
            _context.SaveChanges();
            return Ok();
        }


        // DELETE /api/customers/1
        [HttpDelete]
        public  IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
