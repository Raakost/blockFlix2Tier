using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockFlixDLL.Entities
{    
    public class Address : AbstractEntity
    {       
        public string Street { get; set; }
        public int StreetNr { get; set; }
        public string Floor { get; set; }
        public int ZipCode { get; set; }
    }
}
