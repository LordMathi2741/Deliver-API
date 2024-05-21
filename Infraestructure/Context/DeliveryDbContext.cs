using Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Context;

public class DeliveryDbContext(DbContextOptions<DeliveryDbContext>options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Deliver> Delivers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //TODO: Config to Database
        if (!optionsBuilder.IsConfigured)
        {
            throw new Exception("Error with database config");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Client>().ToTable("clients");
        builder.Entity<Client>().HasKey(c => c.Id);
        builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(p => p.Name).IsRequired();
        builder.Entity<Client>().Property(p => p.Email).IsRequired();
        builder.Entity<Client>().HasMany<Deliver>();
        
        builder.Entity<Deliver>().ToTable("delivers");
        builder.Entity<Deliver>().HasKey(c => c.Id);
        builder.Entity<Deliver>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Deliver>().Property(p => p.ClientId).IsRequired();
        builder.Entity<Deliver>().Property(p => p.Date).IsRequired();
        builder.Entity<Deliver>().Property(p => p.Amount).IsRequired();
        builder.Entity<Deliver>().HasOne<Client>().WithMany().HasForeignKey(p => p.ClientId);
        
    }
        
    
}