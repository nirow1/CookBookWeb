using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            if (this.db.Recipes.Count() == 0) {
                string file = System.IO.File.ReadAllText("Records/guides.json");
                string file2 = System.IO.File.ReadAllText("Records/recipes.json");
                string file3 = System.IO.File.ReadAllText("Records/ingredients.json");

                var giudes = JsonSerializer.Deserialize < List<Guides>>(file);
                var recipes = JsonSerializer.Deserialize<List<Recipes>>(file2);
                var ingredients = JsonSerializer.Deserialize<List<Ingredients>>(file3);

                db.AddRange(giudes, recipes, ingredients);
                db.SaveChanges();

            }
        }
    }
}
