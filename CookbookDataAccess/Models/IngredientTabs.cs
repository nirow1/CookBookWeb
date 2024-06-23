using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CookbookDataAccess.Models
{
    public class IngredientTabs
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(5)]
        public string? Measurement { get; set; }

        [Required]
        [MaxLength(50)]
        public int Kcal { get; set; }

        [Required]
        [MaxLength(50)]
        public float Protein { get; set; }
    }
}
