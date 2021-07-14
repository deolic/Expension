using System.Collections.Generic;
using Expension.Database.Dto.Expense;
using Expension.Database.Dto.Expense.IndividualExpense;
using Expension.Database.Dto.Expense.Shopping;

namespace Expension.Services.Expense
{
    public interface IExpenseService
    {
        List<IndividualExpenseDisplayedDataDto> GetIndividualExpenses();
        List<IndividualExpenseDisplayedDataDto> GetIndividualExpensesForUser(int userId);
        IndividualExpenseDisplayedDataDto GetIndividualExpenseById(int id);
        List<ShoppingDisplayedDataDto> GetShoppings();
        List<ShoppingDisplayedDataDto> GetShoppingsForUser(int userId);
        ShoppingDisplayedDataDto GetShoppingById(int id);
        bool DeleteExpense(int id);
        bool AddExpense(ExpenseAddDto expenseData, string type);
    }
}
