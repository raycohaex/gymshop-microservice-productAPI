using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymShopAPI.DAL.Classes;
using GymShopAPI.DAL.Models;
using GymShopAPI.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymShopAPI.DAL.Controllers
{
    public class ProductsDbAccess : IProductsDbAccess
    {
        private readonly ShopContext _context;

        public ProductsDbAccess(ShopContext context)
        {
            //DI
            _context = context;

            //Als database niet bestaat moet ie worden gemaakt en geseed
            _context.Database.EnsureCreated();
        }

        public async Task<Category> GetAllProductsFromSubCategory(string mainCategory, string catName, ProductQueryParameters queryParameters)
        {

            var mainCategoryId = _context.CategoryMain
                .Where(m => m.Name == mainCategory)
                .FirstOrDefault();

            if (mainCategoryId != null)
            {
                // Main category exists
                var subCategoryId = _context.Categories
                .Where(s => s.Name == catName && s.CategoryMainId == mainCategoryId.Id)
                .FirstOrDefault();

                if(subCategoryId != null) { 
                    // Sub category exists and is part of main category
                    var categorizedProducts = _context.Categories
                    .Where(c => c.Name == catName && c.CategoryMainId == mainCategoryId.Id)
                    .Include(p => p.Products)
                    .FirstOrDefaultAsync();
                    return await categorizedProducts;
                } else
                {
                    // Main category exists, sub doesnt.
                    return null;
                }
            }

            // Default return type
            return null;  
        }
        

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                // Product doesn't exist or is not found
                return null;
            }

            return product;
        }

        public async Task<List<Product>> getAllProducts()
        {
            List<Product> products = new List<Product>();

            products = await _context.Products.ToListAsync();

            return products;
        }

        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                // Id's don't match, something went wrong.
                return null;
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(_context.Products.Find(id) == null)
                {
                    return null;
                }
                throw;
            }
            return null;
        }

        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}