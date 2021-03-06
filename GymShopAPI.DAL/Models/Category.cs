using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymShopAPI.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryMainId { get; set; }
        public virtual List<Product> Products { get; set; }
        [JsonIgnore]
        public virtual CategoryMain CategoryMain { get; set; }
    }
}
