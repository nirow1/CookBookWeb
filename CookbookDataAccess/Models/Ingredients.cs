using System.ComponentModel.DataAnnotations;

namespace CookbookDataAccess.Models
{
    public class Ingredients
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public float Volume { get; set; }

        [MaxLength(50)]
        public float Calories { get; set; }

        [MaxLength(50)]
        public float Protein { get; set; }
    }
}
