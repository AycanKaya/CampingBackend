using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Card
    {
        public string CardNo { get; set; }
        public DateTime ExprationDate { get; set; }
        public int CardType { get; set; }
        public string UserId { get; set; } //foreign key 

    }
}
