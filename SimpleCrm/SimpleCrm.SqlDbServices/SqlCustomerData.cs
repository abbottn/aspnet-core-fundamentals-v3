using System;
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

        public void Save(Customer customer)
        {
            //throw new NotImplementedException();
            context.SaveChanges(); 
        }
    }
}
