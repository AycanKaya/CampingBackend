using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities
{
    public class Campsite
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public  string Location { get; set; }

        public int HolidayDestinationID { get; set; }
        public float Rate { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public List<Comment> Comments { get; set; }
        
        public List<Link> Links { get; set; }

        public string OwnerID { get; set; }
        public int VacationSpotID { get; set; }

        public int AdultPrice { get; set; }
        public int ChildPrice { get; set; }
        public DateTime SeasonStartDate { get; set;  }
        public DateTime SeasonCloseDate { get; set; }

    }
}
