﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }

        //[ForeignKey("IdentityUser")]

        //public string IdentityUserId { get; set; }
        //public IdentityUser IdentityUser { get; set; }   

    }
}
