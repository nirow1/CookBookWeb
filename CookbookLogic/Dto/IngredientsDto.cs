using CookbookDataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace CookbookLogic.Dto
{
    public class IngredientsDto
    {
        public IngredientsDto() { }

        public IngredientsDto(Ingredients ingredient)
        {
            Id = ingredient.Id;
            Name = ingredient.Name;
            Volume = ingredient.Volume;
            Calories = ingredient.Calories;
            Protein = ingredient.Protein;
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Volume { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public IngredientTabs? ingredientTabsId { get; set; }

    }
}
