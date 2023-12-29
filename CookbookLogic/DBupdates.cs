using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookLogic
{
    public static class DBUpdates
    {
        public static void GetNutritionalValues()
        {
            using (var context = new RecipeContext())
            {
                context.Database.EnsureCreated();
                var guides = context.Guides.Include(i => i.Ingredients).ToList();

                foreach (var guide in guides)
                {
                    float totalg = 0;
                    float totalP = 0;
                    float totalC = 0;
                    foreach (var ing in guide.Ingredients)
                    {
                        var ingTab = context.IngredientTabs.SingleOrDefault(i => i.Name == ing.Name);
                        if (ingTab != null)
                        {
                            float protein = ingTab.Protein * ing.Volume;
                            float calories = ingTab.Kcal * ing.Volume;
                            if (ing.Protein != protein)
                            {
                                ing.Protein = protein;
                            }
                            if (ing.Calories != protein)
                            {
                                ing.Calories = calories;
                            }
                        }
                        totalg += ing.Volume;
                        totalP += ing.Protein;
                        totalC += ing.Calories;
                    }
                    if(guide.TotalProtein != totalP)
                        guide.TotalProtein = totalP;
                    if (guide.TotalGrams != totalg)
                        guide.TotalGrams = totalg;
                    if(guide.TotalCalories != totalC)
                        guide.TotalCalories = totalC;
                    
                }
                context.SaveChanges();
            }
        }
    }
}
