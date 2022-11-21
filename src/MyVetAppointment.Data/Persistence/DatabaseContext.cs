using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    protected readonly IConfiguration Configuration;
    

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }


  
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        var conn = Configuration.GetConnectionString("WebApiDatabase");
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Bill>()
            .HasOne<Appointment>(x => x.Appointment)
            .WithOne(x=>x.Bill)
            .HasForeignKey<Appointment>(x => x.Id);

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

        // builder.Entity<Customer>().HasMany<Appointment>(x=>x.Appointments).WithOne(x => x.Customer).OnDelete(DeleteBehavior.Cascade);
        // builder.Entity<VetDoctor>().HasMany<Appointment>(x=>x.Appointments).WithOne(x => x.VetDoctor).OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Appointment>().HasOne(x => x.Customer).WithMany(x => x.Appointments).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Appointment>().HasOne(x => x.VetDoctor).WithMany(x => x.Appointments).OnDelete(DeleteBehavior.NoAction);



    }
}