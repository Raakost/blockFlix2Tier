using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockFlixDLL.Entities;

namespace BlockFlixDLL.GatewayServices
{
    public class OrderServiceGateway : IServiceGateway<Order>
    {
        public Order Create(Order t)
        {
            throw new NotImplementedException();
        }

        public Order Get(string email)
        {
            throw new NotImplementedException();
        }

        public Order Get(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Order t)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order t)
        {
            throw new NotImplementedException();
        }
    }
}
