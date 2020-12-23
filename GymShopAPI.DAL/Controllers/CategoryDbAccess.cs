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
    public class CategoryDbAccess : ICategoryDbAccess
    {
        private readonly ShopContext _context;

        public CategoryDbAccess(ShopContext context)
        {
            //DI
            _context = context;

            //Als database niet bestaat moet ie worden gemaakt en geseed
            _context.Database.EnsureCreated();
        }

        public async Task<List<CategoryMain>> GetAllCategories()
        {
            var categories = _context.CategoryMain
                .Include(i => i.Categories)
                .ToListAsync();

            return await categories;
        }

        public async Task<List<CategoryMain>> GetCategoriesByMain(string name)
        {
            var cat = _context.CategoryMain
                .Where(d => d.Name == name)
                .Include(i => i.Categories)
                .ToListAsync();

            if (cat == null)
            {
                return null;
            }

            return await cat;
        }

        public async Task<List<CategoryMain>> GetAllMainCategories()
        {
            var mainCategories = _context.CategoryMain
                .ToListAsync();

            return await mainCategories;
        }
    }
}