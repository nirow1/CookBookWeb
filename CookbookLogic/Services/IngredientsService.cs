using CookbookDataAccess.Models;
using CookbookDataAccess.Persistence;
using CookbookLogic.Dto;

namespace CookbookLogic.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _ingredientsRepository;

        public IngredientsService(IngredientsRepository ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
        }

        public async Task<IEnumerable<IngredientsDto>> GetAllTabs() => (await _ingredientsRepository.Getingredients()).Select(r => new IngredientsDto(r));

        public async Task<IngredientsDto> GetIngredientById(int id)
        {
            var newIngredient = await _ingredientsRepository.GetIngredientById(id);

            if (newIngredient is null)
                throw new KeyNotFoundException($"Recipe with id {id} not found");

            return new IngredientsDto(newIngredient);
        }

        public async Task CreateTab(IngredientsDto ingredient)
        {
            var newIngredient = new Ingredients
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Volume = ingredient.Volume,
                Calories = ingredient.Calories,
                Protein = ingredient.Protein,
            };

            await _ingredientsRepository.CreateIngredient(newIngredient);
        }

        public async Task UpdateTab(IngredientsDto ingredient)
        {
            var existingIngredient = await _ingredientsRepository.GetIngredientById(ingredient.Id) ?? throw new KeyNotFoundException("Recipe not found");

            existingIngredient.Name = ingredient.Name;
            existingIngredient.Volume = ingredient.Volume;
            existingIngredient.Calories = ingredient.Calories;
            existingIngredient.Protein = ingredient.Protein;
            existingIngredient.Id = ingredient.Id;

            await _ingredientsRepository.UpdateIngredient(existingIngredient);
        }

        public Task<bool> DeleteTab(int id) => _ingredientsRepository.DeleteIngredient(id);
        
    }
}
