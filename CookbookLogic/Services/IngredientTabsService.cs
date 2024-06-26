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
            var existingIngredientTab = await _ingredientTabsRepository.GetTabById(ingredientTab.Id) ?? throw new KeyNotFoundException("Recipe not found");

            existingIngredientTab.Name = ingredientTab.Name;
            existingIngredientTab.Measurement = ingredientTab.Measurement;
            existingIngredientTab.Kcal = ingredientTab.Kcal;
            existingIngredientTab.Protein = ingredientTab.Protein;
            existingIngredientTab.Id = ingredientTab.Id;

            await _ingredientTabsRepository.UpdateTab(existingIngredientTab);
        }

        public Task<bool> DeleteTab(int id)
        {
            return _ingredientTabsRepository.DeleteTab(id);
        }
    }
}
