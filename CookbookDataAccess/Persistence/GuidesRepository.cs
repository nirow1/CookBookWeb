using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CookbookDataAccess.Persistence
{
    public class GuidesRepository : BaseRepository
    {
        public GuidesRepository(RecipeContext recipeContext) : base(recipeContext) { }

        public async Task<IEnumerable<Guides>> GetGuides() => await Context.Guides.ToListAsync();

        public async Task CreateGuide(Guides guide)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            await Context.Guides.AddAsync(guide);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task UpdateGuide(Guides guide)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            Context.Guides.Update(guide);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public Task<Guides?> GetGuideById(int id) => Context.Guides.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<bool> DeleteGuide(int id)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            var guide = Context.Guides.FirstOrDefault(r => r.Id == id);

            if (guide is null)
                return false;

            Context.Guides.Remove(guide);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
    }
}
