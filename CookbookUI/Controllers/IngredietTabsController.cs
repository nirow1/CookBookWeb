using CookbookLogic.Dto;
using Microsoft.AspNetCore.Mvc;
using CookbookLogic.Services;

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
            var tabs = await _ingredientTabsService.GetAllTabs();
            return View(tabs);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Kcal,Protein,Measurement")] IngredientTabsDto tab)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _ingredientTabsService.CreateTab(tab);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex);
                }
            }

            return View(tab);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var tab = await _ingredientTabsService.GetTabById(id);
                return View(tab);
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

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Kcal,Protein,Measurement")] IngredientTabsDto tab)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _ingredientTabsService.UpdateTab(tab);
                    return RedirectToAction(nameof(Index));
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
            return View(tab);
        }

    }
}
