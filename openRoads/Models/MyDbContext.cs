using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace openRoadsWebAPI.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> x) : base(x)
        {

        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.\\REPORTING;Database=openRoads;Trusted_Connection=True;");
//            }
//        }

        public DbSet<Branch> Branch { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeEmployeeRoles> EmployeeEmployeeRoles { get; set; }
        public DbSet<EmployeeRoles> EmployeeRoles { get; set; }
        public DbSet<Insurance> Insurance { get; set; }
        public DbSet<LoginData> LoginData { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleCategory> VehicleCategory { get; set; }
        public DbSet<VehicleFuelType> VehicleFuelType { get; set; }
        public DbSet<VehicleManufacturer> VehicleManufacturer { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<VehicleTransmissionType> VehicleTransmissionType { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
    }
}
