using CookbookDataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace CookbookLogic.Dto
{
    public class RecipeDto
    {
        public RecipeDto() { }

        public RecipeDto(Recipes recipe)
        {
            Id = recipe.Id;
            Name = recipe.Name;
            Category = recipe.Category;
            Source = recipe.Source;
            Score = recipe.Score;
            LastCooked = recipe.LastCooked;
            Guides = recipe.Guides.Select(g => new GuidesDto(g)).ToList();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Source { get; set; }
        public float Score { get; set; }
        public DateTime LastCooked { get; set; }
        public List<GuidesDto> Guides { get; set; } = new List<GuidesDto>();
    }
}
