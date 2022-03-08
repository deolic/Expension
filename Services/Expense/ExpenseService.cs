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
            var expenses = _expenseRepository.FindAll().OrderBy(e => e.ShoppingDate)
                .Select(e =>
                    new ExpenseDisplayedDataDto(e.ExpenseId, e.ShoppingDate,
                        e.BoughtItems.Select(bi =>
                                new BoughtItemDisplayedDto(bi.BoughtItemId, bi.Price,
                                    new ItemDisplayedDto(bi.Item.Name, bi.Item.ItemType))).ToList())).ToList();
            return expenses;
        }

        public List<ExpenseDisplayedDataDto> GetExpensesForUser(int userId)
        {
            var expenses = _expenseRepository.FindByCondition(e => e.UserId == userId).OrderByDescending(e => e.ShoppingDate)
                .Select(e =>
                    new ExpenseDisplayedDataDto(e.ExpenseId, e.ShoppingDate,
                        e.BoughtItems.Select(bi =>
                                new BoughtItemDisplayedDto(bi.BoughtItemId, bi.Price,
                                    new ItemDisplayedDto(bi.Item.Name, bi.Item.ItemType))).ToList())).ToList();
            return expenses;
        }

        public List<ExpenseDisplayedDataDto> GetExpensesForUserByMonth(int userId, int month, int year)
        {
            var expenses = _expenseRepository.FindByCondition(e => e.UserId == userId && e.ShoppingDate.Month == month && e.ShoppingDate.Year == year)
                .OrderByDescending(e => e.ShoppingDate)
                .Select(e => new ExpenseDisplayedDataDto(e.ExpenseId, e.ShoppingDate,
                        e.BoughtItems.Select(bi =>
                                new BoughtItemDisplayedDto(bi.BoughtItemId, bi.Price,
                                    new ItemDisplayedDto(bi.Item.Name, bi.Item.ItemType))).ToList())).ToList();
            return expenses;
        }

        public ExpenseDisplayedDataDto GetExpenseById(int id)
        {
            var expense = _expenseRepository.FindSingleByCondition(e => e.ExpenseId == id);
            var boughtItems = _expenseRepository.FindByCondition(e => e.ExpenseId == id)
                .SelectMany(e => e.BoughtItems.Select(bi =>
                    new BoughtItemDisplayedDto(bi.BoughtItemId, bi.Price, new ItemDisplayedDto(bi.Item.Name, bi.Item.ItemType))))
                .ToList();
            return expense == null
                ? null
                : new ExpenseDisplayedDataDto(expense.ExpenseId, expense.ShoppingDate, boughtItems);
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
