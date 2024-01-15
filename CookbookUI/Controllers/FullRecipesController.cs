using CookbookDataAccess.DataAccess;
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
                       join gui in context.Guides
                       on rec.Id equals gui.Id into guideGroup
                       select new {Id = rec.Id, Name = rec.Name, Score = rec.Score, Category = rec.Category, LastCooked = rec.LastCooked,  GuideList =guideGroup.ToList()};

            return View(data.ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipes = await context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipes == null)
            {
                return NotFound();
            }

            return View(recipes);
        }
    }
}
