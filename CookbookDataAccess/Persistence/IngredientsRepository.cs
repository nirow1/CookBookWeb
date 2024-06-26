using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CookbookDataAccess.Persistence
{
    public class IngredientsRepository : BaseRepository
    {
        public IngredientsRepository(RecipeContext recipeContext) : base(recipeContext) { }

        public async Task<IEnumerable<Ingredients>> Getingredients() => await Context.Ingredients.ToListAsync();

        public async Task CreateIngredient(Ingredients Ingredient)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            await Context.Ingredients.AddAsync(Ingredient);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task UpdateIngredient(Ingredients Ingredient)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            Context.Ingredients.Update(Ingredient);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public Task<Ingredients?> GetIngredientById(int id) => Context.Ingredients.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> DeleteIngredient(int id)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            var Ingredient = Context.Ingredients.FirstOrDefault(r => r.Id == id);

            if (Ingredient is null)
                return false;

            Context.Ingredients.Remove(Ingredient);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
    }
}
