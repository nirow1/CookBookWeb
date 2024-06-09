using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookDataAccess.Persistence
{
    public class RecipesRepository : BaseRepository
    {
        public RecipesRepository(RecipeContext recipeContext): base(recipeContext)
        {
        }

        /// <summary>
        /// Fetches all recipes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Recipes>> GetAllRecipes()
        {
            return await Context.Recipes.ToListAsync();
        }

        /// <summary>
        /// Fetches a single recipe by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Recipes?> GetRecipeById(int id)
        {
            return Context.Recipes.Include(r => r.Guides).FirstOrDefaultAsync(r => r.Id == id);
        }

        /// <summary>
        /// Creates recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public async Task CreateRecipe(Recipes recipe)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            await Context.Recipes.AddAsync(recipe);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        /// <summary>
        /// Updates recipe
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        public async Task UpdateRecipe(Recipes recipe)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            Context.Recipes.Update(recipe);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        /// <summary>
        /// Deletes recipe by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteRecipe(int id)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            var recipe = Context.Recipes.FirstOrDefault(r => r.Id == id);

            if (recipe is null)
                return false;

            Context.Recipes.Remove(recipe);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
    }
}
