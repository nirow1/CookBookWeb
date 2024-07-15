using CookbookDataAccess.Models;
using CookbookDataAccess.Persistence;
using CookbookLogic.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookLogic.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _recipesRepository;

        public RecipesService(RecipesRepository recipesRepository)
        {
            _recipesRepository = recipesRepository;
        }

        /// <summary>
        /// Returns all available recipes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RecipeDto>> GetAllRecipes()
        {
            return (await _recipesRepository.GetAllRecipes()).Select(r => new RecipeDto(r));
        }

        /// <summary>
        /// Returns single recipe by its id
        /// </summary>
        /// <param name="id">Recipe identifier</param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException">Thrown if recipe with id was not found</exception>
        public async Task<RecipeDto> GetRecipeById(int id)
        {
            var recipe = await _recipesRepository.GetRecipeById(id);

            if (recipe is null)
                throw new KeyNotFoundException($"Recipe with id {id} not found");

            return new RecipeDto(recipe);
        }

        /// <summary>
        /// Creates a recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task CreateRecipe(RecipeDto recipe)
        {
            var newRecipe = new Recipe
            {
                Name = recipe.Name,
                Category = recipe.Category,
                Source = recipe.Source,
                Score = recipe.Score,
                LastCooked = recipe.LastCooked
            };

            await _recipesRepository.CreateRecipe(newRecipe);
        }

        /// <summary>
        /// Updates a recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task UpdateRecipe(RecipeDto recipe)
        {
            var existingRecipe = await _recipesRepository.GetRecipeById(recipe.Id) ?? throw new KeyNotFoundException("Recipe not found");

            existingRecipe.Name = recipe.Name;
            existingRecipe.Category = recipe.Category;
            existingRecipe.Source = recipe.Source;
            existingRecipe.Score = recipe.Score;
            existingRecipe.LastCooked = recipe.LastCooked;

            await _recipesRepository.UpdateRecipe(existingRecipe);
        }

        public Task<bool> DeleteRecipe(int id)
        {
            return _recipesRepository.DeleteRecipe(id);
        }
    }
}
