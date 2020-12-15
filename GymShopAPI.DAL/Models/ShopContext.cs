using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymShopAPI.DAL.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(a => a.Category).HasForeignKey(a => a.CategoryId);
            modelBuilder.Entity<CategoryMain>().HasMany(c => c.Categories).WithOne(a => a.CategoryMain).HasForeignKey(a => a.CategoryMainId);

            modelBuilder.Seed();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryMain> CategoryMain { get; set; }
    }
}
