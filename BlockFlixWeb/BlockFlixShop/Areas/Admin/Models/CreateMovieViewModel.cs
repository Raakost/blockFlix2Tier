using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlockFlixDLL.Entities;

namespace BlockFlixAdmin.Models
{
    public class CreateMovieViewModel
    {
        public Movie Movie { get; set; } 
        public List<Genre> Genres { get; set; }
        public List<int> GenreId { get; set; } = new List<int>();
    }
}