using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymShopAPI.DAL.Models
{
    public class CategoryMain
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Category> Categories { get; set; }
    }
}
