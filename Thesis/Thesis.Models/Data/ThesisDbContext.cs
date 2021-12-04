using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Thesis.Models.Data
{
    public class ThesisDbContext : DbContext
    {

        public ThesisDbContext(DbContextOptions<ThesisDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Device>().ToTable("Devices");
            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
