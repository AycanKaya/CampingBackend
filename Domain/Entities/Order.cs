using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int PlaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumOfAdult { get; set; }
        public int NumOfChilder { get; set; }
        public bool isPaid { get; set; }


    }
}
