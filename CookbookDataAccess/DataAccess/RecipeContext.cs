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
        public RecipeContext() { }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<IngredientTab> IngredientTab { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CookbookWebDB;Integrated Security=True;");
        }
    }
}
