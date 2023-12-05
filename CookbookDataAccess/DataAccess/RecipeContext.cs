using CookbookDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookbookDataAccess.DataAccess
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Guide> Guide { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CaloryTab> CaloryTab { get; set; }
    }
}
