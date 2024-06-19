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
    public class IngredientTabsService
    {
        private readonly IngredientTabsRepository _ingredientTabsRepository;

        public IngredientTabsService(IngredientTabsRepository ingredientTabsRepository)
        {
            _ingredientTabsRepository = ingredientTabsRepository;
        }

        public async Task<IEnumerable<IngredientTabsDto>> GetAllTabs()
        {
            return (await _ingredientTabsRepository.GetIngredientTabs()).Select(r => new IngredientTabsDto(r));
        }

        public async Task CreateTab(IngredientTabsDto ingredientTab)
        {
            var newIngredientTab = new IngredientTabs
            {
                Name = ingredientTab.Name,
                Measurement = ingredientTab.Measurement,
                Kcal = ingredientTab.Kcal,
                Protein = ingredientTab.Protein,
                Id = ingredientTab.Id,
            };

            await _ingredientTabsRepository.CreateTab(newIngredientTab);
        }

        public async Task UpdateTab(IngredientTabsDto ingredientTab)
        {
            var existingingredientTab = await _ingredientTabsRepository.GetTabById(ingredientTab.Id) ?? throw new KeyNotFoundException("Recipe not found");

            existingingredientTab.Name = ingredientTab.Name;
            existingingredientTab.Measurement = ingredientTab.Measurement;
            existingingredientTab.Kcal = ingredientTab.Kcal;
            existingingredientTab.Protein = ingredientTab.Protein;
            existingingredientTab.Id = ingredientTab.Id;

            await _ingredientTabsRepository.UpdateTab(existingingredientTab);
        }

        public Task<bool> DeleteTab(int id)
        {
            return _ingredientTabsRepository.DeleteTab(id);
        }
    }
}
