using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockFlixDLL.Entities
{    
    public class Movie : AbstractEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public string TrailerURL { get; set; }
        public  List<Genre> Genres { get; set; }
    }
}
