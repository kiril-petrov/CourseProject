using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    public class IngredientLinkRepository : BaseRepository<IngredientLink>
    {
        public override void Save(IngredientLink item)
        {
            if (item.RecipeID == 0 && item.IngredientID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, link => link.IngredientID == item.IngredientID && link.RecipeID == item.RecipeID);
            }
        }
    }
}
