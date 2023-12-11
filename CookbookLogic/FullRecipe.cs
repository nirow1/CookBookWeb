using System.Data;
using System.Security.Cryptography.X509Certificates;
using CookbookDataAccess.DataAccess;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace CookbookLogic
{


    public class FullRecipe
    {
        public string? Name { get; private set; }

        public string? score { get; private set; }

        public string? source { get; private set; }

        public int randomVal { get; private set; }

        public FullRecipe()
        {
            
            using (var context = new RecipeContext())
            {
                context.Database.EnsureCreated();
                var recipe = context.Recipes.Single(r=> r.Name == "Chilli con carne");
                Name = recipe.Name;
            }

            randomVal = Random.Shared.Next(1,100);
        }
    }
}
