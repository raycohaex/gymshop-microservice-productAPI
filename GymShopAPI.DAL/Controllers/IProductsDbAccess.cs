using GymShopAPI.DAL.Classes;
using GymShopAPI.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymShopAPI.DAL.Interfaces
{
    public interface IProductsDbAccess
    {
        public Task<Product[]> GetAllProducts(ProductQueryParameters queryParameters);
        public Task<Product> GetProduct(int id);
        public Task<List<Category>> GetAllProductsFromSubCategory(string catName, ProductQueryParameters queryParameters);
        public Task<ActionResult<Product>> PostProduct(Product product);
        public Task<IActionResult> PutProduct(int id, Product product);
        public Task<ActionResult<Product>> DeleteProduct(int id);

    }
}
