using System.Collections.Generic;
using System.Threading.Tasks;
using Expension.Database.Dto.Item;
using Microsoft.EntityFrameworkCore;

namespace Expension.Database.Repositories.Item
{
    public class ItemRepository : BaseRepository<Models.Item>, IItemRepository
    {
        public ItemRepository(ExpensionDataContext context) : base(context)
        {

        }
    }
}
