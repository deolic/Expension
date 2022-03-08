using System;
using System.Collections.Generic;
using Expension.Database.Dto.Expense;

namespace Expension.Services.Expense
{
    public interface IExpenseService
    {
        List<ExpenseDisplayedDataDto> GetExpenses();
        List<ExpenseDisplayedDataDto> GetExpensesForUser(int userId);
        List<ExpenseDisplayedDataDto> GetExpensesForUserByMonth(int userId, int month, int year);
        ExpenseDisplayedDataDto GetExpenseById(int id);
        bool AddExpense(DateTime shoppingDate, int userId);
        bool DeleteExpense(int id, int userId);
    }
}
