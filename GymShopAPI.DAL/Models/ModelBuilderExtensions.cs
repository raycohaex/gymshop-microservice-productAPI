using Microsoft.EntityFrameworkCore;

namespace GymShopAPI.DAL.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryMain>().HasData(
                new CategoryMain { Id = 1, Name = "Men" },
                new CategoryMain { Id = 2, Name = "Women" },
                new CategoryMain { Id = 3, Name = "Unisex" },
                new CategoryMain { Id = 4, Name = "Supplements" },
                new CategoryMain { Id = 5, Name = "Accessories" },
                new CategoryMain { Id = 6, Name = "uncategorized" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Active Wear", CategoryMainId = 1 },
                new Category { Id = 2, Name = "Shirts", CategoryMainId = 1 },
                new Category { Id = 3, Name = "Pants", CategoryMainId = 1 },

                new Category { Id = 4, Name = "Active Wear", CategoryMainId = 2 },
                new Category { Id = 5, Name = "Tops", CategoryMainId = 2 },
                new Category { Id = 6, Name = "Pants", CategoryMainId = 2 },

                new Category { Id = 7, Name = "Active Wear", CategoryMainId = 3 },
                new Category { Id = 8, Name = "Beverages", CategoryMainId = 4 },

                new Category { Id = 9, Name = "Publications", CategoryMainId = 5 },
                new Category { Id = 10, Name = "Weights", CategoryMainId = 5 },
                new Category { Id = 11, Name = "Publications", CategoryMainId = 5 },

                new Category { Id = 12, Name = "Whey", CategoryMainId = 4 },
                new Category { Id = 13, Name = "Casein", CategoryMainId = 4 },
                new Category { Id = 14, Name = "Creatine", CategoryMainId = 4 },
                new Category { Id = 15, Name = "Pre-Workout", CategoryMainId = 4 },
                new Category { Id = 16, Name = "Post-Workout", CategoryMainId = 4 },
                new Category { Id = 17, Name = "Vitamins", CategoryMainId = 4 },
                new Category { Id = 18, Name = "uncategorized", CategoryMainId = 6 });
                
                

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "AWMGSJ", Price = 68, IsAvailable = true },
                new Product { Id = 2, CategoryId = 1, Name = "Polo Shirt", Sku = "AWMPS", Price = 35, IsAvailable = true },
                new Product { Id = 3, CategoryId = 1, Name = "Skater Graphic T-Shirt", Sku = "AWMSGT", Price = 33, IsAvailable = true },
                new Product { Id = 4, CategoryId = 1, Name = "Slicker Jacket", Sku = "AWMSJ", Price = 125, IsAvailable = true },
                new Product { Id = 5, CategoryId = 1, Name = "Thermal Fleece Jacket", Sku = "AWMTFJ", Price = 60, IsAvailable = true },
                new Product { Id = 6, CategoryId = 1, Name = "Unisex Thermal Vest", Sku = "AWMUTV", Price = 95, IsAvailable = true },
                new Product { Id = 7, CategoryId = 1, Name = "V-Neck Pullover", Sku = "AWMVNP", Price = 65, IsAvailable = true },
                new Product { Id = 8, CategoryId = 1, Name = "V-Neck Sweater", Sku = "AWMVNS", Price = 65, IsAvailable = true },
                new Product { Id = 9, CategoryId = 1, Name = "V-Neck T-Shirt", Sku = "AWMVNT", Price = 17, IsAvailable = true },
                new Product { Id = 10, CategoryId = 2, Name = "Bamboo Thermal Ski Coat", Sku = "AWWBTSC", Price = 99, IsAvailable = true },
                new Product { Id = 11, CategoryId = 2, Name = "Cross-Back Training Tank", Sku = "AWWCTT", Price = 0, IsAvailable = false },
                new Product { Id = 12, CategoryId = 2, Name = "Grunge Skater Jeans", Sku = "AWWGSJ", Price = 68, IsAvailable = true },
                new Product { Id = 13, CategoryId = 2, Name = "Slicker Jacket", Sku = "AWWSJ", Price = 125, IsAvailable = true },
                new Product { Id = 14, CategoryId = 2, Name = "Stretchy Dance Pants", Sku = "AWWSDP", Price = 55, IsAvailable = true },
                new Product { Id = 15, CategoryId = 2, Name = "Ultra-Soft Tank Top", Sku = "AWWUTT", Price = 22, IsAvailable = true },
                new Product { Id = 16, CategoryId = 2, Name = "Unisex Thermal Vest", Sku = "AWWUTV", Price = 95, IsAvailable = true },
                new Product { Id = 17, CategoryId = 2, Name = "V-Next T-Shirt", Sku = "AWWVNT", Price = 17, IsAvailable = true },
                new Product { Id = 18, CategoryId = 8, Name = "Blueberry Mineral Water", Sku = "MWB", Price = 2.8M, IsAvailable = true },
                new Product { Id = 19, CategoryId = 8, Name = "Lemon-Lime Mineral Water", Sku = "MWLL", Price = 2.8M, IsAvailable = true },
                new Product { Id = 20, CategoryId = 8, Name = "Orange Mineral Water", Sku = "MWO", Price = 2.8M, IsAvailable = true },
                new Product { Id = 21, CategoryId = 8, Name = "Peach Mineral Water", Sku = "MWP", Price = 2.8M, IsAvailable = true },
                new Product { Id = 22, CategoryId = 8, Name = "Raspberry Mineral Water", Sku = "MWR", Price = 2.8M, IsAvailable = true },
                new Product { Id = 23, CategoryId = 8, Name = "Strawberry Mineral Water", Sku = "MWS", Price = 2.8M, IsAvailable = true },
                new Product { Id = 24, CategoryId = 8, Name = "In the Kitchen with H+ Sport", Sku = "PITK", Price = 24.99M, IsAvailable = true },
                new Product { Id = 25, CategoryId = 17, Name = "Calcium 400 IU (150 tablets)", Sku = "SC400", Price = 9.99M, IsAvailable = true },
                new Product { Id = 26, CategoryId = 17, Name = "Flaxseed Oil 100 mg (90 capsules)", Sku = "SFO100", Price = 12.49M, IsAvailable = true },
                new Product { Id = 27, CategoryId = 17, Name = "Iron 65 mg (150 caplets)", Sku = "SI65", Price = 13.99M, IsAvailable = true },
                new Product { Id = 28, CategoryId = 17, Name = "Magnesium 250 mg (100 tablets)", Sku = "SM250", Price = 12.49M, IsAvailable = true },
                new Product { Id = 29, CategoryId = 17, Name = "Multi-Vitamin (90 capsules)", Sku = "SMV", Price = 9.99M, IsAvailable = true },
                new Product { Id = 30, CategoryId = 17, Name = "Vitamin A 10,000 IU (125 caplets)", Sku = "SVA", Price = 11.99M, IsAvailable = true },
                new Product { Id = 31, CategoryId = 17, Name = "Vitamin B-Complex (100 caplets)", Sku = "SVB", Price = 12.99M, IsAvailable = true },
                new Product { Id = 32, CategoryId = 17, Name = "Vitamin C 1000 mg (100 tablets)", Sku = "SVC", Price = 9.99M, IsAvailable = true },
                new Product { Id = 33, CategoryId = 17, Name = "Vitamin D3 1000 IU (100 tablets)", Sku = "SVD3", Price = 12.49M, IsAvailable = true });

        }
    }
}
