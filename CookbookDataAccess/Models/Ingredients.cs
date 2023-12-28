using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookbookDataAccess.Models
{
    public class Ingredients
    {
        public int Id {  get; set; }

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
