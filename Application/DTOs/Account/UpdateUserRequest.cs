﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Account
{
    public class UpdateUserRequest
    {
      
        
        public string FirstName { get; set; }
     
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }

        public string PhoneNumber { get; set; }
   
       
        public string UserName { get; set; }

    }
}
