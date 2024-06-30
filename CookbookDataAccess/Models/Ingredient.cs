using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookbookDataAccess.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public float Volume { get; set; }

        [MaxLength(50)]
        public float Calories { get; set; }

        [MaxLength(50)]
        public float Protein { get; set; }

        [ForeignKey(nameof(Models.Guide))]
        public int GuidesId { get; set; }

        public virtual Guide Guide { get; set; } = null!;

        [ForeignKey(nameof(Models.IngredientTabs))]
        public int IngredientTabId { get; set; }

        public virtual IngredientTabs IngredientTab { get; set; } = null!;
    }
}
