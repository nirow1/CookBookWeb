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
                    foreach(var ing in guide.Ingredients)
                    {
                        if(ing.Protein == null) { }
                    }
                }
            }
        }
    }
}
