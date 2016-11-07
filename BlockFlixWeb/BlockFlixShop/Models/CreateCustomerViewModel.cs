using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlockFlixDLL.Entities;

namespace BlockFlixShop.Models
{
    public class CreateCustomerViewModel
    {
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}