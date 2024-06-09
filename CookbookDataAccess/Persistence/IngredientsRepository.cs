using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CookbookDataAccess.Persistence
{
    public class IngredientsRepository : BaseRepository
    {
        public IngredientsRepository(RecipeContext recipeContext) : base(recipeContext)
        {
        }

        public async Task<IEnumerable<Ingredients>> GetIngredients()
        {
            return await Context.Ingredients.ToListAsync();
        }
    }
}
