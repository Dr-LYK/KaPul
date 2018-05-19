using System;
using Microsoft.EntityFrameworkCore;
using Kapul.Services.Identity.DBO;

namespace Kapul.Services.Identity.DataAccess
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Passenger>().ToTable("Passenger");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
