using Information_system_i_ASP.Net.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Information_system_i_ASP.Net.Data
{
    public class AppDbContext : IdentityDbContext<Employee>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverEvent> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Drivers
            modelBuilder.Entity<Driver>().HasData(
                new Driver
                {
                    DriverID = 1,
                    DriverName = "David Thompson",
                    CarReg = "DHT567",
                    NoteDate = DateTime.Now.AddDays(-1),
                    NoteDescription = "Completed morning shift deliveries",
                    ResponsibleEmployee = "Chris Allen",
                    BeloppIn = 550.00m,
                    BeloppUt = 180.00m,
                    TotalBeloppIn = 550.00m,
                    TotalBeloppUt = 180.00m
                },
                new Driver
                {
                    DriverID = 2,
                    DriverName = "Nina Foster",
                    CarReg = "QWE234",
                    NoteDate = DateTime.Now.AddDays(-2),
                    NoteDescription = "Routine vehicle check-up",
                    ResponsibleEmployee = "Logistics Admin",
                    BeloppIn = 0.00m,
                    BeloppUt = 150.00m,
                    TotalBeloppIn = 0.00m,
                    TotalBeloppUt = 150.00m
                },
                new Driver
                {
                    DriverID = 3,
                    DriverName = "Victor Garcia",
                    CarReg = "TYU789",
                    NoteDate = DateTime.Now.AddDays(-3),
                    NoteDescription = "Delivered beverages",
                    ResponsibleEmployee = "Sara Lee",
                    BeloppIn = 430.00m,
                    BeloppUt = 160.00m,
                    TotalBeloppIn = 430.00m,
                    TotalBeloppUt = 160.00m
                },
                new Driver
                {
                    DriverID = 4,
                    DriverName = "Charlotte Adams",
                    CarReg = "GHJ456",
                    NoteDate = DateTime.Now.AddDays(-4),
                    NoteDescription = "Nighttime courier service",
                    ResponsibleEmployee = "Patrick Hill",
                    BeloppIn = 620.00m,
                    BeloppUt = 210.00m,
                    TotalBeloppIn = 620.00m,
                    TotalBeloppUt = 210.00m
                },
                new Driver
                {
                    DriverID = 5,
                    DriverName = "Ethan Rivera",
                    CarReg = "BVC901",
                    NoteDate = DateTime.Now.AddDays(-5),
                    NoteDescription = "Transported office supplies",
                    ResponsibleEmployee = "Nancy Green",
                    BeloppIn = 750.00m,
                    BeloppUt = 320.00m,
                    TotalBeloppIn = 750.00m,
                    TotalBeloppUt = 320.00m
                },
                new Driver
                {
                    DriverID = 6,
                    DriverName = "Isabella Roberts",
                    CarReg = "UJM123",
                    NoteDate = DateTime.Now.AddDays(-6),
                    NoteDescription = "Delivered pharmaceuticals",
                    ResponsibleEmployee = "Mark Stevenson",
                    BeloppIn = 950.00m,
                    BeloppUt = 370.00m,
                    TotalBeloppIn = 950.00m,
                    TotalBeloppUt = 370.00m
                },
                new Driver
                {
                    DriverID = 7,
                    DriverName = "Jack Morgan",
                    CarReg = "LKJ234",
                    NoteDate = DateTime.Now.AddDays(-7),
                    NoteDescription = "Handled electronics delivery",
                    ResponsibleEmployee = "Laura Knight",
                    BeloppIn = 1150.00m,
                    BeloppUt = 450.00m,
                    TotalBeloppIn = 1150.00m,
                    TotalBeloppUt = 450.00m
                }
            );

            // Seed data for Events
            modelBuilder.Entity<DriverEvent>().HasData(
                new DriverEvent { DriverEventID = 1, BeloppIn = 420.00m, BeloppUt = 60.00m, DriverID = 1, NoteDate = DateTime.Now.AddDays(-1), NoteDescription = "Morning delivery completed" },
                new DriverEvent { DriverEventID = 2, BeloppIn = 0.00m, BeloppUt = 320.00m, DriverID = 2, NoteDate = DateTime.Now.AddDays(-2), NoteDescription = "Engine oil change" },
                new DriverEvent { DriverEventID = 3, BeloppIn = 0.00m, BeloppUt = 120.00m, DriverID = 1, NoteDate = DateTime.Now.AddDays(-3), NoteDescription = "Fuel refilled" },
                new DriverEvent { DriverEventID = 4, BeloppIn = 440.00m, BeloppUt = 70.00m, DriverID = 3, NoteDate = DateTime.Now.AddDays(-4), NoteDescription = "Beverages delivered" },
                new DriverEvent { DriverEventID = 5, BeloppIn = 640.00m, BeloppUt = 130.00m, DriverID = 4, NoteDate = DateTime.Now.AddDays(-5), NoteDescription = "Overnight delivery route" },
                new DriverEvent { DriverEventID = 6, BeloppIn = 780.00m, BeloppUt = 180.00m, DriverID = 5, NoteDate = DateTime.Now.AddDays(-6), NoteDescription = "Office supplies delivered" },
                new DriverEvent { DriverEventID = 7, BeloppIn = 980.00m, BeloppUt = 240.00m, DriverID = 6, NoteDate = DateTime.Now.AddDays(-7), NoteDescription = "Pharmaceuticals dispatched" },
                new DriverEvent { DriverEventID = 8, BeloppIn = 1250.00m, BeloppUt = 350.00m, DriverID = 7, NoteDate = DateTime.Now.AddDays(-8), NoteDescription = "High-end electronics delivered" }
            );
        }
    }
}
