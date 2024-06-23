using CookbookLogic.Dto;
using Microsoft.AspNetCore.Mvc;
using CookbookLogic.Services;
using Microsoft.EntityFrameworkCore;

namespace CookbookUI.Controllers
{
    public class IngredientTabsController : Controller
    {

        private readonly IngredientTabsService _ingredientTabsService;

        public IngredientTabsController(IngredientTabsService ingredientTabsService)
        {
            _ingredientTabsService = ingredientTabsService;
        }

        public async Task<IActionResult> Index()
        {
            var ingredients = await _ingredientTabsService.GetAllTabs();
            return View(ingredients);
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var recipe = await _ingredientTabsService.GetTabById(id);
                return View(recipe);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Kcal,Protein,Measurement")] IngredientTabsDto ingredientTab)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _ingredientTabsService.CreateTab(ingredientTab);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }

            return View(ingredientTab);
        }

    }
}
