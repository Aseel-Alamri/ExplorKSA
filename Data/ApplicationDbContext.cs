using FinalWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Event> events { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<UserSelection> Userselection { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<ReservationOption> Reservation { get; set; }
        public DbSet<Booking> Bookings { get; set; }


    }
}
