using CookbookDataAccess.DataAccess;
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
            }
        }
    }
}
