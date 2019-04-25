using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamientoWeb.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
        }

        public int VehicleId { get; set; }
        [CheckForCaps]
        public string Brand { get; set; }
        [CheckForCaps]
        public string Model { get; set; }
        [CheckForCaps]
        public string Style { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}