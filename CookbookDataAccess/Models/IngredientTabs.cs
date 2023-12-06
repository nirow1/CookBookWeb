using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookbookDataAccess.Models
{
    public class IngredientTabs
    {
        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }

        [MaxLength(5)]
        public string? Measurement { get; set; }

        [MaxLength(50)]
        public int Kcal { get; set; }

        [MaxLength(50)]
        public float Protein { get; set; }
    }
}
