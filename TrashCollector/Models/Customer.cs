using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {   
         public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PickupDay { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string StartSuspension { get; set; }
        public string EndSuspension { get; set; }
        public bool isSuspended { get; set; }
        public double Balance { get; set; }
        public string OneTimePickup { get; set; }

        //[ForeignKey("IdentityUser")]

        //public string IdentityUserId { get; set; }
        //public IdentityUser IdentityUser { get; set; }       
    }
}
