using CookbookDataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace CookbookDataAccess.Persistence
{
    public class BaseRepository
    {
        protected RecipeContext Context;

        public BaseRepository(RecipeContext context)
        {
            Context = context;
        }
    }
}
