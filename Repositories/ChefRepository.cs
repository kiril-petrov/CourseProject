using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    public class ChefRepository : BaseRepository<Chef>
    {
        public override void Save(Chef item)
        {
            if (item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, chef => chef.ID == item.ID);
            }
        }
    }
}
