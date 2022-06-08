using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class HolidayDestination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName  { get; set; }
        public string Information { get; set; }
        public Link FotoUri { get; set; }


    }
}
