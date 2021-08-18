using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace WebThesis.Models
{
    public class ThesisDbContext : DbContext
    {
        public ThesisDbContext()
        {
            Database.EnsureCreatedAsync();
        }

        static string database = "dbThesis.db";
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Data> Data { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Filename=" + database,
                sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(
                        Assembly.GetExecutingAssembly().FullName

                        );
                });

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>(entity => { entity.HasKey(e => e.Id); });
            modelBuilder.Entity<Device>().ToTable("Devices");
            modelBuilder.Entity<Device>(entity => { entity.HasKey(e => e.Id); });
            modelBuilder.Entity<Data>().ToTable("Data");
            modelBuilder.Entity<Data>(entity => { entity.HasKey(e => e.Id); });

            base.OnModelCreating(modelBuilder);
        }
    }
}
