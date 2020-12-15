using GymShopAPI.DAL.Classes;
using GymShopAPI.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymShopAPI.DAL.Interfaces
{
    public interface ICategoryDbAccess
    {
        public Task<List<CategoryMain>> GetAllCategories();
        public Task<List<CategoryMain>> GetCategoriesByMain(string name);
    }
}
