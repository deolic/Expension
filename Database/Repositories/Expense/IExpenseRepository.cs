using System;
using System.Linq;
using System.Linq.Expressions;
using Expension.Database.Models;

namespace Expension.Database.Repositories.Expense
{
    public interface IExpenseRepository : IBaseRepository<Models.Expense>
    {
        IQueryable<IndividualExpense> FindAllIndividualExpenses();
        IQueryable<IndividualExpense> FindIndividualExpensesByCondition(Expression<Func<IndividualExpense, bool>> expression);
        IndividualExpense FindSingleIndividualExpenseByCondition(Expression<Func<IndividualExpense, bool>> expression);
        IQueryable<Shopping> FindAllShoppings();
        IQueryable<Shopping> FindShoppingsByCondition(Expression<Func<Shopping, bool>> expression);
        Shopping FindSingleShoppingByCondition(Expression<Func<Shopping, bool>> expression);
    }
}
