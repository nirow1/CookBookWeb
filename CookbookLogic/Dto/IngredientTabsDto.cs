using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookbookDataAccess.Models;

namespace CookbookLogic.Dto
{
    internal class IngredientTabsDto
    {
        public IngredientTabsDto() { }

        public IngredientTabsDto(IngredientTabs ingredientTabs)
        {
            Id = ingredientTabs.Id;
            Name = ingredientTabs.Name;
            Measurement = ingredientTabs.Measurement;
            Kcal = ingredientTabs.Kcal;
            Protein = ingredientTabs.Protein;
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Measurement { get; set; }
        public int Kcal { get; set; }
        public float Protein { get; set; }

    }
}
