using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymShopAPI.DAL.Classes;
using GymShopAPI.DAL.Controllers;
using GymShopAPI.DAL.Models;
using GymShopAPI.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace GymShopAPI.BLL.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsDbAccess _ProductsDbAccess;

        public ProductsController(IProductsDbAccess ProductsDbAccess)
        {
            //DI
            _ProductsDbAccess = ProductsDbAccess;
        }

        [HttpGet("category/{mainCategory}/{catName}")]
        public async Task<ActionResult<Category>> GetAllProductsFromSubCategory(string mainCategory, string catName, [FromQuery] ProductQueryParameters queryParameters)
        {
            var products = await _ProductsDbAccess.GetAllProductsFromSubCategory(mainCategory, catName, queryParameters);

            if (products == null)
            {
                // This explicitly means that either of the categories is not found.
                // This shouldn't happen if the categories exist but there's simply no products.
                return NotFound();
            }

            return products;
        }

        //extra argument {id} zorgt ervoor dat er een extra argument word toegevoegd aan de huidige controller, de url is dus product/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _ProductsDbAccess.GetProduct(id);
            if(product != null)
            {
                return product;
            }
            return NotFound();
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Product>>> getAllProducts([FromQuery] int index)
        {
            var product = await _ProductsDbAccess.getAllProducts();
            if (product != null)
            {
                return product;
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            await _ProductsDbAccess.PostProduct(product);

            return CreatedAtAction(
                "GetProduct",
                new { id = product.Id },
                product
                );
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _ProductsDbAccess.PutProduct(id, product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            return await _ProductsDbAccess.DeleteProduct(id);
        }
    }
}