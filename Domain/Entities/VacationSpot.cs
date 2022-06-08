using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class VacationSpot
    {
        
        public int Id { get;}
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Capacity { get; set; }
        public bool isValid { get; set; }

    }

}
