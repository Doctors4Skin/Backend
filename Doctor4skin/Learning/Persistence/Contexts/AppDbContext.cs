using Microsoft.EntityFrameworkCore;
using Doctor4skin.Learning.Domain.Models;
using Doctor4skin.Shared.Extensions;

namespace Doctor4skin.Learning.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; } = default!;
    public DbSet<Patient> Patients { get; set; } = default!;
    public DbSet<Reservation> Reservations { get; set; } = default!;
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Doctors
        builder.Entity<Doctor>().ToTable("Doctors");
        builder.Entity<Doctor>().HasKey(d => d.Id);
        builder.Entity<Doctor>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        //Patients
        builder.Entity<Patient>().ToTable("Patients");
        builder.Entity<Patient>().HasKey(p => p.Id);
        builder.Entity<Patient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //Reservation
        builder.Entity<Reservation>().ToTable("Reservations");
        builder.Entity<Reservation>().HasKey(r => r.Id);
        builder.Entity<Reservation>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Reservation>().HasOne(r => r.Patient);

        builder.Entity<Reservation>().HasOne(r => r.Doctor);

        builder.UseSnakeCaseNamingConvention();
    }
}
