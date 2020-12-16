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

        public async Task<Product[]> GetAllProducts(ProductQueryParameters queryParameters)
        {
            IQueryable<Product> products = _context.Products;

            if (queryParameters.MinPrice != null && queryParameters.MaxPrice != null)
            {
                products = products.Where(
                    p => p.Price >= queryParameters.MinPrice.Value &&
                         p.Price <= queryParameters.MaxPrice.Value
                );
            }

            if (!string.IsNullOrEmpty(queryParameters.Sku))
            {
                products = products.Where(p => p.Sku == queryParameters.Sku);
            }

            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                products = products.Where(
                    p => p.Name.ToLower().Contains(queryParameters.Name.ToLower()));
            }

            //products = products
            //   .Skip(queryParameters.Size * (queryParameters.Page - 1))
            //    .Take(queryParameters.Size);
            return await products.ToArrayAsync();
        }

        public async Task<List<Category>> GetAllProductsFromSubCategory(string catName, ProductQueryParameters queryParameters)
        {
            var categorizedProducts = _context.Categories
                .Where(c => c.Name == catName)
                .Include(p => p.Products)
                .ToListAsync();


            //products = products
            //   .Skip(queryParameters.Size * (queryParameters.Page - 1))
            //    .Take(queryParameters.Size);
            return await categorizedProducts;
        }
        

        public async Task<Product> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
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
                // als ID's niet matchen krijg je bad request (500)
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