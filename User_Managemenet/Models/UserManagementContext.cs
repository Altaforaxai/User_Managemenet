using Microsoft.EntityFrameworkCore;
using User_Managemenet.Models;

namespace User_Managemenet.Models
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, Name = "Electronics" },
                new ProductCategory { Id = 2, Name = "Books" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 999.99m, ProductCategoryId = 1 },
                new Product { Id = 2, Name = "Novel", Price = 19.99m, ProductCategoryId = 2 }
            );
        }
    }
}
