using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamientoWeb.Models
{
    public class Invoice
    {
        public Invoice()
        {
        }

        public int InvoiceId { get; set; }

        public int VehicleId { get; set; }

        public DateTime Date { get; set; }
        public double Maintenance { get; set; }
        public double Tax { get; set; }
        public double CostByStyle { get; set; }
        public double Profit { get; set; }
        public double Total { get; set; }
    }
}