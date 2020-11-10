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

        [HttpGet]
        public async Task<Product[]> GetAllProducts([FromQuery] ProductQueryParameters queryParameters)
        {
            return await _ProductsDbAccess.GetAllProducts(queryParameters);
        }

        //extra argument {id} zorgt ervoor dat er een extra argument word toegevoegd aan de huidige controller, de url is dus product/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _ProductsDbAccess.GetProduct(id);
        }

        [HttpPost]
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
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            return await _ProductsDbAccess.DeleteProduct(id);
        }
    }
}