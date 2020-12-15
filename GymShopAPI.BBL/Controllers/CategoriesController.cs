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

namespace GymShopAPI.BBL.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryDbAccess _CategoryDbAccess;

        public CategoriesController(ICategoryDbAccess CategoryDbAccess)
        {
            //DI
            _CategoryDbAccess = CategoryDbAccess;
        }

        [HttpGet]
        public async Task<List<CategoryMain>> GetAllCategories()
        {
            return await _CategoryDbAccess.GetAllCategories();
        }

        //extra argument {id} zorgt ervoor dat er een extra argument word toegevoegd aan de huidige controller, de url is dus product/{id}
        [HttpGet("{name}")]
        public async Task<List<CategoryMain>> GetCategory(string name)
        {
            return await _CategoryDbAccess.GetCategoriesByMain(name);
        }
    }
}