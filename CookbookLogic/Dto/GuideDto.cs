using CookbookDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookLogic.Dto
{
    public class GuideDto
    {
        public GuideDto()
        {
              
        }

        public GuideDto(Guide guides)
        {
            Id = guides.Id;
            RecipeId = guides.RecipeId;
            Type = guides.Type;
            Score = guides.Score;
            WritenGuide = guides.WritenGuide;
            TotalCalories = guides.TotalCalories;
            TotalProtein = guides.TotalProtein;
            TotalGrams = guides.TotalGrams;
        }

        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string? Type { get; set; }
        public float Score { get; set; }
        public string? WritenGuide { get; set; }
        public float TotalCalories { get; set; }
        public float TotalProtein { get; set; }
        public float TotalGrams { get; set; }
    }
}
