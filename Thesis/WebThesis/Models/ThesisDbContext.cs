using System;
namespace WebThesis.Models
{
    public class ThesisDbContext
    {
        static string database = "db Thesis.db";
        public DbSet<Users> Users { get; set; }
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
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Users>(entity => { entity.HasKey(e => e.Id); });
            modelBuilder.Entity<Device>().ToTable("Devices");
            modelBuilder.Entity<Device>(entity => { entity.HasKey(e => e.Id); });
            modelBuilder.Entity<Data>().ToTable("Data");
            modelBuilder.Entity<Data>(entity => { entity.HasKey(e => e.Id); });

            base.OnModelCreating(modelBuilder);
        }
    }
}
