using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace CookBookWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RecipeContext db;

        public IndexModel(ILogger<IndexModel> logger, RecipeContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            LoadSampleData();

        }

        public void LoadSampleData() 
        {
            if (this.db.IngredientTabs.Count() == 0) {
                string file3 = System.IO.File.ReadAllText("Records/ingredients.json");
                var ingredientTabs = JsonSerializer.Deserialize<List<IngredientTabs>>(file3);

                db.AddRange(ingredientTabs);
                db.SaveChanges();

            }
            if (this.db.Recipes.Count() == 0)
            {
                string file2 = System.IO.File.ReadAllText("Records/recipes.json");
                var recipes = JsonSerializer.Deserialize<List<Recipes>>(file2);


                db.AddRange(recipes);
                db.SaveChanges();

            }
        }
    }
}
