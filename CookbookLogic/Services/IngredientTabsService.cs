using CookbookDataAccess.Models;
using CookbookDataAccess.Persistence;
using CookbookLogic.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookLogic.Services
{
    class IngredientTabsService
    {
        private readonly IngredientTabsRepository _ingredientTabsRepository;

        public IngredientTabsService(IngredientTabsRepository ingredientTabsRepository)
        {
            _ingredientTabsRepository = ingredientTabsRepository;
        }

        public async Task<IEnumerable<IngredientTabsDto>> GetAllRecipes()
        {
            return (await _ingredientTabsRepository.GetIngredientTabs()).Select(r => new IngredientTabsDto(r));
        }

        public async Task CreateRecipe(IngredientTabsDto ingredientTab)
        {
            var newIngredientTab = new IngredientTabs
            {
                Name = ingredientTab.Name,
                Measurement = ingredientTab.Measurement,
                Kcal = ingredientTab.Kcal,
                Protein = ingredientTab.Protein,
                Id = ingredientTab.Id,
            };

            await _ingredientTabsRepository.CreateIngredientTab(newIngredientTab);
        }

        public async Task UpdateRecipe(IngredientTabsDto ingredientTab)
        {
            var existingingredientTab = await _ingredientTabsRepository.GetRecipeById(ingredientTab.Id) ?? throw new KeyNotFoundException("Recipe not found");

            existingingredientTab.Name = ingredientTab.Name;
            existingingredientTab.Measurement = ingredientTab.Measurement;
            existingingredientTab.Kcal = ingredientTab.Kcal;
            existingingredientTab.Protein = ingredientTab.Protein;
            existingingredientTab.Id = ingredientTab.Id;

            await _ingredientTabsRepository.UpdateIngredientTab(existingingredientTab);
        }

        public Task<bool> DeleteRecipe(int id)
        {
            return _ingredientTabsRepository.DeleteRecipe(id);
        }
    }
}
