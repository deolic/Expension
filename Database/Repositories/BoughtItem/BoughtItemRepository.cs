namespace Expension.Database.Repositories.BoughtItem
{
    public class BoughtItemRepository : BaseRepository<Models.BoughtItem>, IBoughtItemRepository
    {
        public BoughtItemRepository(ExpensionDataContext context) : base(context)
        {

        }
    }
}
