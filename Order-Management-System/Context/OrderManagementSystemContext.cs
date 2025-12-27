using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Order_Management_System.Models;

namespace Order_Management_System.Context
{
    public class OrderManagementSystemContext : IdentityDbContext<User , IdentityRole<Guid> , Guid>
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }

        public OrderManagementSystemContext(DbContextOptions<OrderManagementSystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(OrderManagementSystemContext).Assembly);
        }
    }
}
