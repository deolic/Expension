namespace Expension.Database.Repositories.Expense
{
    public class ExpenseRepository : BaseRepository<Models.Expense>, IExpenseRepository
    {
        public ExpenseRepository(ExpensionDataContext context) : base(context)
        {

        }
    }
}
