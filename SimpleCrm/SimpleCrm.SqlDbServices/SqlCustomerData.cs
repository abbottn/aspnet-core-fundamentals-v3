﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrm.SqlDbServices
{
    public class SqlCustomerData : ICustomerData
    {
        private readonly SimpleCrmDbContext context;

        public SqlCustomerData(SimpleCrmDbContext context)
        {
            this.context = context;
        }

        public Customer Get(int id)
        {
           //throw new NotImplementedException();
           return context.Customer.FirstOrDefault(x => x.Id == id);  // access table of customers
        }

        public IEnumerable<Customer> GetAll()
        {
            //throw new NotImplementedException();
            return context.Customer.ToList();
        }

        public void Add(Customer customer)
        {
            context.Customer.Add(customer);  // fixed after DBContext Implementation submitted
            context.SaveChanges(); 
        }
        public void Update(Customer customer)
        {
            // context.Customer.Update(customer);  
            context.SaveChanges();
        }
    }
}
