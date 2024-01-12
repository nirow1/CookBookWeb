using System.Data;
using CookbookDataAccess.DataAccess;
using CookbookDataAccess.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Web;


namespace CookbookLogic
{


    public class FullRecipesController // : Controller
    {
        private readonly RecipeContext RecipeContext;

        public FullRecipesController(RecipeContext recipeContext)
        {
            this.RecipeContext = recipeContext;
        }

        /*public IActionResult Index()
        {
            var data = from rec in this.RecipeContext.Recipes
                       join gui in this.RecipeContext.Guides
                       on rec.Id equals gui.Id into guideGroup select new
                       {
                           rec.Name,
                           rec.Source,
                           rec.Score,
                           rec.Category,
                           rec.LastCooked,
                           GuideList = guideGroup.ToList(),
                       };
            return (IActionResult)View(data.ToList());
        }*/
    }
}
