using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using CookbookLogic.Services;
using CookbookLogic.Dto;

namespace CookbookUI.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipesService _recipesService;

        public RecipesController(RecipesService recipesService)
        {
            _recipesService = recipesService;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var recipes = await _recipesService.GetAllRecipes();
            return View(recipes);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var recipe = await _recipesService.GetRecipeById(id);
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

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var recipe = await _recipesService.GetRecipeById(id);
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

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Category,Source,Score,LastCooked")] RecipeDto recipe)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _recipesService.UpdateRecipe(recipe);
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
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var recipe = await _recipesService.GetRecipeById(id);
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

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _recipesService.DeleteRecipe(id);

            if (!deleted)
                return Conflict(deleted);

            return RedirectToAction(nameof(Index));
        }
    }
}
