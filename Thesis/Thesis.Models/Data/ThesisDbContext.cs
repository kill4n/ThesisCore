using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Thesis.Models.Data
{
    public class ThesisDbContext : DbContext
    {
        public string DbPath { get; private set; }
        static string database = "dbSqlite.db";
        public ThesisDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"C:/db{System.IO.Path.DirectorySeparatorChar}{database}";
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}",
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
