using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CookbookDataAccess.Persistence
{
    public class IngredientTabsRepository : BaseRepository
    {
        public IngredientTabsRepository(RecipeContext recipeContext) : base(recipeContext) { }

        public async Task<IEnumerable<IngredientTab>> GetTabs() => await Context.IngredientTabs.ToListAsync();

        public async Task CreateTab(IngredientTab ingredientTab)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            await Context.IngredientTabs.AddAsync(ingredientTab);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task UpdateTab(IngredientTab ingredientTab)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            Context.IngredientTabs.Update(ingredientTab);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public Task<IngredientTab?> GetTabById(int id) => Context.IngredientTabs.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> DeleteTab(int id)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            var ingredientTab = Context.IngredientTabs.FirstOrDefault(r => r.Id == id);

            if (ingredientTab is null)
                return false;

            Context.IngredientTabs.Remove(ingredientTab);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
    }
}
