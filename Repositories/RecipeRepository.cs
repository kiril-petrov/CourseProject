using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;


namespace Repositories
{
    public class RecipeRepository : BaseRepository<Recipe>
    {
        public override void Save(Recipe item)
        {
            if(item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, recipe => recipe.ID == item.ID);
            }
        }
    }
}
