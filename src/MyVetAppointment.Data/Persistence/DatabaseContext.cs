using Microsoft.EntityFrameworkCore;
using MyVetAppointment.Data.Entities;

namespace MyVetAppointment.Data.Persistence
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<VetDoctor> VetDoctors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .HasOne(b => b.Bill)
                .WithOne(a => a.Appointment)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Appointment>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.Appointments)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appointment>()
                .HasOne(x => x.VetDoctor)
                .WithMany(x => x.Appointments)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}