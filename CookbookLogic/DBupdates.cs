using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookLogic
{
    public class DBUpdates
    {
        public void GetNutritionalValues()
        {
            using (var context = new RecipeContext())
            {
                context.Database.EnsureCreated();

                foreach (var guide in context.Guides)
                {
                    var ingrediant = from ing in guide.Ingredients
                                        join tab in context.IngredientTabs
                                        on ing.Name equals tab.Name
                                        select new
                                        {
                                            name = ing.Name,
                                            Protein = ing.Volume * tab.Protein,
                                            Calories = ing.Volume * tab.Kcal
                                        };
                    /*foreach(var ing in guide.Ingredients)
                    {
                        if (ing.Protein == 0)
                        {
                        }
                    }*/
                }
            }
        }
    }
}
