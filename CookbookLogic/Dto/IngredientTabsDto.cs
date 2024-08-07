﻿using CookbookDataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace CookbookLogic.Dto
{
    public class IngredientTabsDto
    {
        public IngredientTabsDto() { }

        public IngredientTabsDto(IngredientTab ingredientTabs)
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
