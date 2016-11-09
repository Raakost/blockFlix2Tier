using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockFlixDLL.Entities;

namespace BlockFlixDLL.GatewayServices
{
    public class CustomerServiceGateway : IServiceGateway<Customer>
    {
        public Customer Create(Customer t)
        {
            throw new NotImplementedException();
        }

        public Customer Get(string email)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Customer t)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer t)
        {
            throw new NotImplementedException();
        }
    }
}
