using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CookbookLogic
{

    public static class DbUpdates
    {
        public static async Task GetNutritionalValues()
        {
            try
            {
                using var context = new RecipeContext();
                await context.Database.EnsureCreatedAsync();
                var guides = await context.Guides.Include(i => i.Ingredients).ToListAsync();

                foreach (var guide in guides)
                {
                    UpdateNutritionalValues(context, guide);
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateNutritionalValues(RecipeContext context, Guides guide)
        {
            float totalGrams = 0;
            float totalProtein = 0;
            float totalCalories = 0;
            foreach (var ingredient in guide.Ingredients)
            {
                UpdateIngredientNutritionalValues(context, ingredient);
                totalGrams += ingredient.Volume;
                totalProtein += ingredient.Protein;
                totalCalories += ingredient.Calories;
            }
            if (guide.TotalProtein != totalProtein)
            {
                guide.TotalProtein = totalProtein;
            }
            if (guide.TotalGrams != totalGrams)
            {
                guide.TotalGrams = totalGrams;
            }
            if (guide.TotalCalories != totalCalories)
            {
                guide.TotalCalories = totalCalories;
            }
        }

        private static void UpdateIngredientNutritionalValues(RecipeContext context, Ingredients ingredient)
        {
            var ingredientTab = context.IngredientTabs.SingleOrDefault(i => i.Name == ingredient.Name);
            if (ingredientTab != null)
            {
                float protein = ingredientTab.Protein * ingredient.Volume;
                float calories = ingredientTab.Kcal * ingredient.Volume;
                if (ingredient.Protein != protein)
                {
                    ingredient.Protein = protein;
                }
                if (ingredient.Calories != protein)
                {
                    ingredient.Calories = calories;
                }
            }
        }
    }
}
