using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication10.Models
{
    public class CampDbContext : DbContext
    {
        public DbSet<Campground> campgrounds { get; set; }
        public DbSet<Booking> bookings { get; set; }

        public DbSet<Customer> customers { get; set; }
    }
}