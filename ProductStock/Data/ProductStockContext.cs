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

            builder.Entity<Product>()
                .HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.IdCategory);

            builder.Entity<OrderProduct>()
                .HasOne(orderProduct => orderProduct.Order)
                .WithMany(order => order.OrderProducts)
                .HasForeignKey(orderProduct => orderProduct.IdOrder);

            builder.Entity<OrderProduct>()
                .HasOne(orderProduct => orderProduct.Product)
                .WithMany(product => product.OrderProducts)
                .HasForeignKey(orderProduct => orderProduct.IdProduct);
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
