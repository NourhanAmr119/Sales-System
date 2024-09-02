using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class FilterAttribute
    {
        public string CustomerFilter { get; set; }
        public int QuantityFilter { get; set; }
        public string RegionFilter { get; set; }
        public string ProductFilter { get; set; }
    }
}
