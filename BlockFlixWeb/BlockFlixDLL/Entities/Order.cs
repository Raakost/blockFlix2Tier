using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockFlixDLL.Entities
{
    [Serializable]
    public class Order : AbstractEntity
    {
        public  List<Movie> Movies { get; set; } 
        public  Customer Customer { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}