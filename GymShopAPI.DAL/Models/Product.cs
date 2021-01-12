using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GymShopAPI.DAL.Models
{
    public class Product : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CategoryId == 0)
            {
                yield return new ValidationResult(
                    "No category has been selected, if you meant to have the product uncategorized please select that option.",
                    new[] { nameof(CategoryId) });
            }
        }
    }
}
