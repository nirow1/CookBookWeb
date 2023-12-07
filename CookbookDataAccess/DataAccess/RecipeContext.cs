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
        public DbSet<Guides> Guides { get; set; }
        public DbSet<IngredientTabs> IngredientTabs { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
    }
}
