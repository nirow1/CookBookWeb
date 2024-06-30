using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookbookDataAccess.Models
{
    public class Guide
    {
        [Required]
        [MaxLength(50)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Type { get; set; }

        [MaxLength(50)]
        public float Score { get; set; }

        [Required]
        [MaxLength(500)]
        public string? WritenGuide { get; set; }

        [MaxLength(50)]
        public float TotalCalories { get; set; }

        [MaxLength(50)]
        public float TotalProtein { get; set; }

        [MaxLength(50)]
        public float TotalGrams { get; set; }

        [ForeignKey(nameof(Recipes))]
        public int RecipeId { get; set; }

        public virtual Recipes Recipes { get; set; } = null!;

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }
}
