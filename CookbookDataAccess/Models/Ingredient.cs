using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookbookDataAccess.Models
{
    public class Ingredient
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public int TabId { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public float Volume { get; set; }

        [MaxLength(5)]
        public string? Measurement { get; set; }

        [MaxLength(50)]
        public float Calories { get; set; }

        [MaxLength(50)]
        public float Protein { get; set; }
    }
}
