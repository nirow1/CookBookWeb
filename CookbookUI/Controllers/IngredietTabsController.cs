using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using CookbookLogic.Dto;
using CookbookLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CookbookUI.Controllers
{
    public class IngredientTabsController : Controller
    {

        private readonly IngredientTabsService _ingredientTabsService;

        public IngredientTabsController(IngredientTabsService ingredientTabsService)
        {
            _ingredientsTabsService = ingredientTabsService;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Category,Source,Score,LastCooked")] RecipeDto recipes)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _recipesService.CreateRecipe(recipes);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }

            return View(recipes);
        }

    }
}
