using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookDataAccess.Models
{
    public class Recipe
    {
        [Required]
        [MaxLength(50)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Category { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Source { get; set; }

        [Required]
        [MaxLength(20)]
        public float Score { get; set; }

        [Required]
        public DateTime LastCooked { get; set; }

        public virtual ICollection<Guide> Guides { get; set; } = new List<Guide>();
    }
}
