using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenProvider.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country GetCountry { get; set; }
    }
}
