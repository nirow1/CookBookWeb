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

        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<Guides> Guide { get; set; }
        public DbSet<IngredientTabs> Ingredients { get; set; }
        public DbSet<Ingredients> CaloryTab { get; set; }
    }
}
