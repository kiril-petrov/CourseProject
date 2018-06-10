using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient>
    {
        public override void Save(Ingredient item)
        {
            if (item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, ingredient => ingredient.ID == item.ID);
            }

        }
    }
}
