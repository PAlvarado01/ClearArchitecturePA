using ClearArchitecture.Entities.CAEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArchitecture.Repositories.EFCore.DataContext
{
    public class ClearArchitectureContext : DbContext
    {
        public ClearArchitectureContext(DbContextOptions<ClearArchitectureContext> options) :
            base(options)
        { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<Products>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerId)
                .IsRequired()
                .HasMaxLength(5)
                .IsFixedLength();
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCity)
                .HasMaxLength(15);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCountry)
                .HasMaxLength(15);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipPostalCode)
                .HasMaxLength(10);
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId);
            modelBuilder.Entity<OrderDetail>()
                .HasOne<Products>()
                .WithMany()
                .HasForeignKey(od => od.ProductId);
            modelBuilder.Entity<Products>()
                .HasData(
                new Products { Id = 1, Name = "Chai"},
                new Products { Id = 2, Name = "Chang" },
                new Products { Id = 3, Name = "Aniseed Syrup"}
                );
            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { Id = "ALFKI", Name = "Alfreds F." },
                new Customer { Id = "ANATR", Name = "Ana Trujillo" },
                new Customer { Id = "ANTON", Name = "Antonio Moreno" }
                );
        }
    }
}
