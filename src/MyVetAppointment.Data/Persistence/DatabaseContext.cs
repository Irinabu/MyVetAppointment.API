using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Data.Persistence;

public class DatabaseContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Drug> Drugs { get; set; }
    public DbSet<VetDoctor> VetDoctors { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CustomerVetDoctor> CustomerVetDoctors { get; set; }


    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Bill>()
            .HasOne<Appointment>(x => x.Appointment);

        builder.Entity<CustomerVetDoctor>()
            .HasKey(x => new { x.CustomerId, x.VetDoctorId });

        builder.Entity<CustomerVetDoctor>()
            .HasOne<Customer>(x => x.Customer)
            .WithMany(x => x.VetDoctors)
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<CustomerVetDoctor>()
            .HasOne<VetDoctor>(x => x.VetDoctor)
            .WithMany(x => x.Customers)
            .HasForeignKey(x => x.VetDoctorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Appointment>()
            .HasOne(x => x.Customer)
            .WithMany(x => x.Appointments)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<Appointment>()
            .HasOne(x => x.VetDoctor)
            .WithMany(x => x.Appointments)
            .OnDelete(DeleteBehavior.NoAction);
    }
}