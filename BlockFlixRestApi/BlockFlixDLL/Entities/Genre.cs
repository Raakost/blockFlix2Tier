using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlockFlixDLL.Entities
{
    public class Genre : AbstractEntity
    {
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
