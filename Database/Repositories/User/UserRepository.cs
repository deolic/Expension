namespace Expension.Database.Repositories.User
{
    public class UserRepository : BaseRepository<Models.User>, IUserRepository
    {
        public UserRepository(ExpensionDataContext context) : base(context)
        {

        }
    }
}
