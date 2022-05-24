using System;
using Microsoft.EntityFrameworkCore;
using ProductStock.Models;

namespace ProductStock.Data
{
    public class ProductStockContext : DbContext
    {
        public ProductStockContext(DbContextOptions<ProductStockContext> opt) : base (opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>()
                .HasOne(address => address.Client)
                .WithOne(client => client.Address)
                .HasForeignKey<Client>(client => client.IdAddress);
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
    }
}
