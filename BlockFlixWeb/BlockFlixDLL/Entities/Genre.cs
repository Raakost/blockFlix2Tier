﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlockFlixDLL.Entities
{
    public class Genre : AbstractEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public  List<Movie> Movies { get; set; }
    }
}
