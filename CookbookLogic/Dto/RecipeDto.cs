﻿using CookbookDataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace CookbookLogic.Dto
{
    public class RecipeDto
    {
        public RecipeDto() { }

        public RecipeDto(Recipe recipe)
        {
            Id = recipe.Id;
            Name = recipe.Name;
            Category = recipe.Category;
            Source = recipe.Source;
            Score = recipe.Score;
            LastCooked = recipe.LastCooked;
            Guides = recipe.Guides.Select(g => new GuideDto(g)).ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Source { get; set; } = null!;
        public float Score { get; set; }
        public DateTime LastCooked { get; set; }
        public List<GuideDto> Guides { get; set; } = new List<GuideDto>();
    }
}
