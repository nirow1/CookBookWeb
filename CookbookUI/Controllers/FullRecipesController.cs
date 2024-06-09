using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CookbookUI.Controllers
{
    public class FullRecipesController : Controller
    {

        private readonly RecipeContext context;

        public FullRecipesController(RecipeContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var data = from rec in context.Recipes
                       select new {Id = rec.Id, Name = rec.Name, Score = rec.Score, Category = rec.Category, LastCooked = rec.LastCooked};

            return View(data.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var recipes = from rec in context.Recipes
                          join gui in context.Guides.Include(g => g.Ingredients)
                          on rec.Id equals gui.Id into guideGroup
                          select new { Id = rec.Id, Name = rec.Name, Source = rec.Source, Score = rec.Score, Category = rec.Category, LastCooked = rec.LastCooked, Guides= guideGroup.ToList()};
            var fullRecipe = await recipes.FirstOrDefaultAsync(m => m.Id == id);
            
            if (fullRecipe == null)
            {
                return NotFound();
            }

            return View(fullRecipe);
        }
    }
}
