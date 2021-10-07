using System;
using System.Collections.Generic;
using System.Linq;
using Expension.Database.Dto.BoughtItem;
using Expension.Database.Dto.Expense;
using Expension.Database.Dto.Item;
using Expension.Database.Repositories.Expense;

namespace Expension.Services.Expense
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public List<ExpenseDisplayedDataDto> GetExpenses()
        {
            var expenses = _expenseRepository.FindAll()
                .Select(e =>
                    new ExpenseDisplayedDataDto(e.ShoppingDate,
                        e.BoughtItems.Select(bi =>
                                new BoughtItemDisplayedDto(bi.Price,
                                    new ItemDisplayedDto(bi.Item.Name, bi.Item.ItemType)))
                            .ToList())).ToList();
            return expenses;
        }

        public List<ExpenseDisplayedDataDto> GetExpensesForUser(int userId)
        {
            var expenses = _expenseRepository.FindByCondition(e => e.UserId == userId)
                .Select(e =>
                    new ExpenseDisplayedDataDto(e.ShoppingDate,
                        e.BoughtItems.Select(bi =>
                                new BoughtItemDisplayedDto(bi.Price,
                                    new ItemDisplayedDto(bi.Item.Name, bi.Item.ItemType)))
                            .ToList())).ToList();
            return expenses;
        }

        public ExpenseDisplayedDataDto GetExpenseById(int id)
        {
            var expense = _expenseRepository.FindSingleByCondition(ie => ie.ExpenseId == id);
            return expense == null
                ? null
                : new ExpenseDisplayedDataDto(expense.ShoppingDate,
                    expense.BoughtItems.Select(bi =>
                            new BoughtItemDisplayedDto(bi.Price, new ItemDisplayedDto(bi.Item.Name, bi.Item.ItemType)))
                        .ToList());
        }

         public bool AddExpense(DateTime shoppingDate, int userId)
         {
             var expense = new Database.Models.Expense
             {
                 ShoppingDate = shoppingDate,
                 UserId = userId
             };
             _expenseRepository.Create(expense);
             _expenseRepository.Save();
             return true;
         }

        public bool DeleteExpense(int id, int userId)
        {
            var expense = _expenseRepository.FindSingleByCondition(e => e.ExpenseId == id && e.UserId == userId);
            if (expense == null)
            {
                return false;
            }
            _expenseRepository.Delete(expense);
            _expenseRepository.Save();
            return true;
        }
    }
}
