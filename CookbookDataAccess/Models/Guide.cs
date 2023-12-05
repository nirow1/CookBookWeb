using System.ComponentModel.DataAnnotations;

namespace CookbookDataAccess.Models
{
    public class Guide
    {
        [Required]
        [MaxLength(50)]
        public int Id { get; set; }
        public List<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();

        [Required]
        [MaxLength(500)]
        public string? WritenGuide { get; set; }

        [MaxLength(50)]
        public float TotalCalories { get; set; }

        [MaxLength(50)]
        public float TotalProtein { get; set; }
    }
}
