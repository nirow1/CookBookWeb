using System.ComponentModel.DataAnnotations;

namespace CookbookDataAccess.Models
{
    public class Guides
    {
        [Required]
        [MaxLength(50)]
        public int Id { get; set; }

        [Required]
        public List<Ingredients>? Ingredients { get; set; } = new List<Ingredients>();

        [Required]
        [MaxLength(500)]
        public string? WritenGuide { get; set; }

        [MaxLength(50)]
        public float TotalCalories { get; set; }

        [MaxLength(50)]
        public float TotalProtein { get; set; }

        [MaxLength(50)]
        public float TotalGrams { get; set; }
    }
}
