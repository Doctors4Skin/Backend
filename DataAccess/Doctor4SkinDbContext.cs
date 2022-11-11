using Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class Doctor4SkinDbContext : DbContext
    {
        public Doctor4SkinDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-LDN4SJN\\SQLEXPRESS;Database=Doctor4Skin;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>();
            modelBuilder.Entity<Patient>();
        }
    }
}