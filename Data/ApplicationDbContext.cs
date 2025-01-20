using FinalWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalWebApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Event> Events { get; set; }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<UserSelection> Userselection { get; set; }



    }
}
