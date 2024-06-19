using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CookbookDataAccess.Persistence
{
    public class IngredientTabsRepository : BaseRepository
    {
        public IngredientTabsRepository(RecipeContext recipeContext) : base(recipeContext) { }

        public async Task<IEnumerable<IngredientTabs>> GetIngredientTabs()
        {
            return await Context.IngredientTabs.ToListAsync();
        }

        public async Task CreateIngredientTab(IngredientTabs ingredientTab)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            await Context.IngredientTabs.AddAsync(ingredientTab);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task UpdateIngredientTab(IngredientTabs ingredientTab)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            Context.IngredientTabs.Update(ingredientTab);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task<bool> DeleteRecipe(int id)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            var ingredientTab = Context.Recipes.FirstOrDefault(r => r.Id == id);

            if (ingredientTab is null)
                return false;

            Context.Recipes.Remove(ingredientTab);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
    }
}
