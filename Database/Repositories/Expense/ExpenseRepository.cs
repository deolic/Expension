using System;
using System.Linq;
using System.Linq.Expressions;
using Expension.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Expension.Database.Repositories.Expense
{
    public class ExpenseRepository : BaseRepository<Models.Expense>, IExpenseRepository
    {
        public ExpenseRepository(ExpensionDataContext context) : base(context)
        {

        }

        public IQueryable<IndividualExpense> FindAllIndividualExpenses()
        {
            var query = from ie
                    in _context.Expenses.OfType<IndividualExpense>().Include(ie => ie.BoughtItem)
                select ie;
            var expenses = query.AsNoTracking();
            return expenses;
        }

        public IQueryable<IndividualExpense> FindIndividualExpensesByCondition(Expression<Func<IndividualExpense, bool>> expression)
        {
            var query = from ie
                    in _context.Expenses.OfType<IndividualExpense>().Include(ie => ie.BoughtItem)
                select ie;
            var expenses = query.Where(expression).AsNoTracking();
            return expenses;
        }

        public IndividualExpense FindSingleIndividualExpenseByCondition(Expression<Func<IndividualExpense, bool>> expression)
        {
            var query = from ie 
                in _context.Expenses.OfType<IndividualExpense>().Include(ie => ie.BoughtItem) 
                select ie; 
            var expense = query.Where(expression).AsNoTracking().FirstOrDefault();
            return expense;
        }

        public IQueryable<Shopping> FindAllShoppings()
        {
            var query = from s
                    in _context.Expenses.OfType<Shopping>().Include(s => s.BoughtItems)
                select s;
            var expenses = query.AsNoTracking();
            return expenses;
        }

        public IQueryable<Shopping> FindShoppingsByCondition(Expression<Func<Shopping, bool>> expression)
        {
            var query = from s
                    in _context.Expenses.OfType<Shopping>().Include(s => s.BoughtItems)
                select s;
            var expenses = query.Where(expression).AsNoTracking();
            return expenses;
        }

        public Shopping FindSingleShoppingByCondition(Expression<Func<Shopping, bool>> expression)
        {
            var query = from s
                    in _context.Expenses.OfType<Shopping>().Include(s => s.BoughtItems)
                select s;
            var expense = query.Where(expression).AsNoTracking().FirstOrDefault();
            return expense;
        }
    }
}
