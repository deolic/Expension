using System;
using System.Collections.Generic;
using System.Linq;

using Expension.Database.Dto.Expense.IndividualExpense;
using Expension.Database.Dto.Expense.Shopping;
using Expension.Database.Models;
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

        public List<IndividualExpenseDisplayedDataDto> GetIndividualExpenses()
        {
            var individualExpenses = _expenseRepository.FindAllIndividualExpenses()
                .Select(ie =>
                    new IndividualExpenseDisplayedDataDto(ie.ShoppingDate, ie.BoughtItem)).ToList();
            return individualExpenses;
        }

        public List<IndividualExpenseDisplayedDataDto> GetIndividualExpensesForUser(int userId)
        {
            var individualExpenses = _expenseRepository.FindIndividualExpensesByCondition(ie => ie.UserId == userId)
                .Select(ie =>
                    new IndividualExpenseDisplayedDataDto(ie.ShoppingDate, ie.BoughtItem)).ToList();
            return individualExpenses;
        }

        public IndividualExpenseDisplayedDataDto GetIndividualExpenseById(int id)
        {
            var individualExpense = _expenseRepository.FindSingleIndividualExpenseByCondition(ie => ie.ExpenseId == id);
            return individualExpense == null
                ? null
                : new IndividualExpenseDisplayedDataDto(individualExpense.ShoppingDate, individualExpense.BoughtItem);
        }

        public List<ShoppingDisplayedDataDto> GetShoppings()
        {
            var shoppings = _expenseRepository.FindAllShoppings().Select(s =>
                new ShoppingDisplayedDataDto(s.ShoppingDate, s.BoughtItems)).ToList();
            return shoppings;
        }

        public List<ShoppingDisplayedDataDto> GetShoppingsForUser(int userId)
        {
            var shoppings = _expenseRepository.FindShoppingsByCondition(s => s.UserId == userId).Select(s =>
                new ShoppingDisplayedDataDto(s.ShoppingDate, s.BoughtItems)).ToList();
            return shoppings;
        }

        public ShoppingDisplayedDataDto GetShoppingById(int id)
        {
            var shopping = _expenseRepository.FindSingleShoppingByCondition(s => s.ExpenseId == id);
            return shopping == null ? null : new ShoppingDisplayedDataDto(shopping.ShoppingDate, shopping.BoughtItems);
        }

        public bool AddExpense(DateTime shoppingDate, int userId, string type)
        {
            Database.Models.Expense expense;
            switch (type)
            {
                case "individual":
                    expense = new IndividualExpense()
                    {
                        ShoppingDate = shoppingDate.Date,
                        UserId = userId
                    };
                    break;
                case "shopping":
                    expense = new Shopping()
                    {
                        ShoppingDate = shoppingDate.Date,
                        UserId = userId
                    };
                    break;
                default:
                    return false;
            }
            _expenseRepository.Create(expense);
            _expenseRepository.Save();
            return true;
        }

        public bool DeleteExpense(int id)
        {
            var expense = _expenseRepository.FindSingleByCondition(e => e.ExpenseId == id);
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
