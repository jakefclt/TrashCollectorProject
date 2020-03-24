using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Zipcode")]
        public int ZipCode { get; set; }

        [Display(Name = "Pickup Complete")]
        public bool PickUp { get; set; }

        [ForeignKey("IdentityUser")]

        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public int? Id { get; internal set; }
    }
}
