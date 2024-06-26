using CookbookDataAccess.Persistence;
using CookbookLogic.Dto;
using CookbookDataAccess.Models;

namespace CookbookLogic.Services
{
    public class GuidesService
    {
        private readonly GuidesRepository _guidesRepository;

        public GuidesService(GuidesRepository guidesRepository)
        {
            _guidesRepository = guidesRepository;
        }

        public async Task<IEnumerable<GuidesDto>> GetAllGuides() => (await _guidesRepository.GetGuides()).Select(r => new GuidesDto(r));

        public async Task<GuidesDto> GetGuideById(int id)
        {
            var newIngredientTab = await _guidesRepository.GetGuideById(id);

            if (newIngredientTab is null)
                throw new KeyNotFoundException($"Recipe with id {id} not found");

            return new GuidesDto(newIngredientTab);
        }

        public async Task CreateGuide(GuidesDto Guide)
        {
            var newGuide = new Guides
            {
                Id = Guide.Id,
                RecipeId = Guide.RecipeId,
                Type = Guide.Type,
                Score = Guide.Score,
                WritenGuide = Guide.WritenGuide,
                Ingredients = Guide.Ingredients,
            };

            await _guidesRepository.CreateGuide(newGuide);
        }

        public async Task UpdateGuide(GuidesDto guide)
        {
            var existingGuide = await _guidesRepository.GetGuideById(guide.Id) ?? throw new KeyNotFoundException("Recipe not found");

            existingGuide.Id = guide.Id;
            existingGuide.RecipeId = guide.RecipeId;
            existingGuide.Type = guide.Type;
            existingGuide.Score = guide.Score;
            existingGuide.WritenGuide = guide.WritenGuide;
            existingGuide.Ingredients = guide.Ingredients;

            await _guidesRepository.UpdateGuide(existingGuide);
        }

        public Task<bool> DeleteGuide(int id) => _guidesRepository.DeleteGuide(id);
    }
}
