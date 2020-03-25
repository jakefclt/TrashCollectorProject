using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class ConfirmPickupViewModel
    {
        public bool Pickup { get; set; }
        public int CustomerId { get; internal set; }
    }
}
