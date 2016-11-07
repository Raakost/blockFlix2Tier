using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockFlixDLL.Entities
{
    [Serializable]
    public class Customer : AbstractEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
