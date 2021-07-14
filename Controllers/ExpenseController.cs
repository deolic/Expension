using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Expension.Database.Dto.Expense;
using Expension.Database.Dto.Expense.IndividualExpense;
using Expension.Database.Dto.Expense.Shopping;
using Expension.Services.Expense;

namespace Expension.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        // GET api/expenses/individual
        [HttpGet("individual")]
        public ActionResult<List<IndividualExpenseDisplayedDataDto>> GetAllIndividualExpenses()
        {
            return _expenseService.GetIndividualExpenses();
        }
        // GET api/expenses/shopping
        [HttpGet("shopping")]
        public ActionResult<List<ShoppingDisplayedDataDto>> GetAllShoppings()
        {
            return _expenseService.GetShoppings();
        }

        // GET api/expenses/individual/{id}
        [HttpGet("individual/{id}")]
        public ActionResult<IndividualExpenseDisplayedDataDto> GetIndividualExpenseById(int id)
        {
            var expense = _expenseService.GetIndividualExpenseById(id);
            return expense != null
                ? (ActionResult<IndividualExpenseDisplayedDataDto>) expense
                : NotFound(new {message = "There is no individual expense with such id"});
        }

        // GET api/expenses/shopping/{id}
        [HttpGet("shopping/{id}")]
        public ActionResult<ShoppingDisplayedDataDto> GetShoppingById(int id)
        {
            var expense = _expenseService.GetShoppingById(id);
            return expense != null
                ? (ActionResult<ShoppingDisplayedDataDto>) expense
                : NotFound(new { message = "There is no shopping with such id" });
        }



        // DELETE api/expenses/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteExpense(int id)
        {
            return _expenseService.DeleteExpense(id) ? NoContent() : (ActionResult) BadRequest(new {message = "There is no expense with such id"});
        }

        // POST api/expenses/{type}
        [HttpPost("{type}")]
        public ActionResult CreateExpense(ExpenseAddDto expenseData, string type)
        {
            return _expenseService.AddExpense(expenseData, type) ? NoContent() : (ActionResult) BadRequest(new {message = "Wrong type of expense" });
        }
    }
}
