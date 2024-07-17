using CookbookDataAccess.Models;
using CookbookDataAccess.Persistence;
using CookbookLogic.Dto;

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
            return (await _ingredientTabsRepository.GetTabs()).Select(r => new IngredientTabsDto(r));
        }

        public async Task<IngredientTabsDto> GetTabById(int id)
        {
            var newIngredientTab = await _ingredientTabsRepository.GetTabById(id);

            if (newIngredientTab is null)
                throw new KeyNotFoundException($"Recipe with id {id} not found");

            return new IngredientTabsDto(newIngredientTab);
        }

        public async Task CreateTab(IngredientTabsDto ingredientTab)
        {
            var newIngredientTab = new IngredientTab
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
