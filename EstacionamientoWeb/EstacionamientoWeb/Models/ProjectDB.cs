using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EstacionamientoWeb.Models
{
    public class ProjectDB : DbContext
    {
        public ProjectDB() : base("DefaultConnection")
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}