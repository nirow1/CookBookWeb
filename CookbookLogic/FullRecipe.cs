using System.Data;
using System.Security.Cryptography.X509Certificates;
using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace CookbookLogic
{


    public class FullRecipe
    {
        public List<Recipes> fullRecipes { get; private set; }

        public FullRecipe()
        {

            using (var context = new RecipeContext())
            {
                context.Database.EnsureCreated();
                fullRecipes = context.Recipes.ToList();
            }
        }

        public static List<Guides> GetRecipeGuide(int Id)
        {
            using (var context = new RecipeContext())
            {
                List<Guides> guides = context.Guides.Where(i => i.Id == Id).ToList();
                return guides;
            }
        }
    }
}
