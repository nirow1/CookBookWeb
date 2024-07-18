using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CookbookDataAccess.Persistence
{
    public class GuideRepository : BaseRepository
    {
        public GuideRepository(RecipeContext recipeContext) : base(recipeContext) { }

        public async Task<IEnumerable<Guide>> GetGuides() => await Context.Guides.ToListAsync();

        public async Task CreateGuide(Guide guide)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            await Context.Guides.AddAsync(guide);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task UpdateGuide(Guide guide)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            Context.Guides.Update(guide);
            await Context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public Task<Guide?> GetGuideById(int id) => Context.Guides.FirstOrDefaultAsync(x => x.Id == id);

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
