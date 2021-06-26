namespace Expension.Database.Repositories.Shopping
{
    public class ShoppingRepository : BaseRepository<Models.Shopping>, IShoppingRepository
    {
        public ShoppingRepository(ExpensionDataContext context) : base(context)
        {

        }
    }
}
