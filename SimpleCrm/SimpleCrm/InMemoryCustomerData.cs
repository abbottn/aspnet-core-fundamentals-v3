﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrm
{
    public class InMemoryCustomerData : ICustomerData
    {
        static IList<Customer> _customers; //not thread safe - only ok for development, single user

        static InMemoryCustomerData()
        {
            _customers = new List<Customer>
            {
                new Customer { Id =1, FirstName ="Bob", LastName = "Jones", PhoneNumber = "555-555-2345" },
                new Customer { Id =2, FirstName ="Jane", LastName = "Smith", PhoneNumber = "555-555-5256" },
                new Customer { Id =3, FirstName ="Mike", LastName = "Doe", PhoneNumber = "555-555-8547" },
                new Customer { Id =4, FirstName ="Karen", LastName = "Jamieson", PhoneNumber = "555-555-9134" },
                new Customer { Id =5, FirstName ="James", LastName = "Dean", PhoneNumber = "555-555-7245" },
                new Customer { Id =6, FirstName ="Michelle", LastName = "Leary", PhoneNumber = "555-555-3457" }
            };
        }

        public Customer Get(int id)
        {
            // throw new NotImplementedException();
            var customer = _customers.FirstOrDefault(x => x.Id == id);
            return customer;
        }
        public void Add(Customer customer)
        {
            customer.Id = _customers.Max(x => x.Id) + 1;
            _customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var customerx = _customers.FirstOrDefault(x => x.Id == customer.Id);
            customerx.FirstName = customer.FirstName;
            customerx.LastName = customer.LastName;
            customerx.PhoneNumber = customer.PhoneNumber;
            customerx.Type = customer.Type;
            customerx.OptInNewsletter = customer.OptInNewsletter;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        
    }
}
