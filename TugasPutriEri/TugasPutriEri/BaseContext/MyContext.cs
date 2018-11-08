using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TugasPutriEri.Model;

namespace TugasPutriEri.BaseContext
{
    class MyContext : DbContext
    {
        public MyContext() : base("TugasPutriEri") { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<Regency> Regencies { get; set; }
        public DbSet<Village> Villages { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<DetailRoom> DetailRooms { get; set; }

    }
}
