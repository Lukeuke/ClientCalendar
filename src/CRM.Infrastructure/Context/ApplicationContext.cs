using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(eb =>
        {
            eb.HasMany(x => x.Calendars)
                .WithOne(x => x.Owner);
        });

        modelBuilder.Entity<Calendar>(eb =>
        {
            eb.HasOne(x => x.Owner)
                .WithMany(x => x.Calendars);

            eb.HasMany(x => x.Bookings)
                .WithOne(x => x.Calendar);

            eb.HasMany(x => x.ServiceTypes)
                .WithOne(x => x.Calendar);
        });
        
        modelBuilder.Entity<Client>(eb =>
        {
            eb.HasOne(x => x.Calendar);
        });

        modelBuilder.Entity<Booking>(eb =>
        {
            eb.HasOne(x => x.Client)
                .WithMany(x => x.Bookings);
        });

        modelBuilder.Entity<ServiceType>(eb =>
        {
            eb.HasOne(x => x.Calendar)
                .WithMany(x => x.ServiceTypes);
        });
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Calendar> Calendars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }
}