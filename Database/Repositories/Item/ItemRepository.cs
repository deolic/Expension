namespace Expension.Database.Repositories.Item
{
    public class ItemRepository : BaseRepository<Models.Item>, IItemRepository
    {
        public ItemRepository(ExpensionDataContext context) : base(context)
        {

        }
    }
}
