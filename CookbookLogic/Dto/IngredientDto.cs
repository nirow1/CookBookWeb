using CookbookDataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookbookLogic.Dto
{
    public class IngredientDto
    {
        public IngredientDto() { }

        public IngredientDto(Ingredient ingredient)
        {
            Id = ingredient.Id;
            Name = ingredient.Name;
            Volume = ingredient.Volume;
            Calories = ingredient.Calories;
            Protein = ingredient.Protein;
            IngredientTabId = ingredient.IngredientTabId;
            IngredientTab = new IngredientTabDto(ingredient.IngredientTab);
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float Volume { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public int IngredientTabId { get; set; }
        public IngredientTabDto IngredientTab { get; set; } = null!;

    }
}
