using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Expension.Services.Expense;
using Expension.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Expension.Database.Dto.Expense;

namespace Expension.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ExpenseController(IExpenseService expenseService, IHttpContextAccessor httpContextAccessor)
        {
            _expenseService = expenseService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET api/expenses/
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public ActionResult<List<ExpenseDisplayedDataDto>> GetAllIndividualExpenses()
        {
            return _expenseService.GetExpenses();
        }

        // GET api/expenses/{id}
        [Authorize(Policy = "LoggedUserOnly")]
        [HttpGet("{id}")]
        public ActionResult<ExpenseDisplayedDataDto> GetExpenseById(int id)
        {
           var expense = _expenseService.GetExpenseById(id);
           return expense != null
               ? (ActionResult<ExpenseDisplayedDataDto>) expense
               : NotFound(new { message = "There is no expense with such id" });
        }

        // GET api/expenses/user/all
        [Authorize(Policy = "LoggedUserOnly")]
        [HttpGet("user/all")]
        public ActionResult<List<ExpenseDisplayedDataDto>> GetExpensesForUser()
        {
            if (_httpContextAccessor.HttpContext == null) return NotFound();
            var userId = StringConversion.ConvertToInt(_httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return _expenseService.GetExpensesForUser(userId);
        }

        // GET api/expenses/user?month=3&year=2022
        [Authorize(Policy = "LoggedUserOnly")]
        [HttpGet("user")]
        public ActionResult<List<ExpenseDisplayedDataDto>> GetExpensesForUserByMonth(int month, int year)
        {
            if (_httpContextAccessor.HttpContext == null) return NotFound();
            var userId = StringConversion.ConvertToInt(_httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return _expenseService.GetExpensesForUserByMonth(userId, month, year);
        }

        // POST api/expenses/
        [Authorize(Policy = "LoggedUserOnly")]
        [HttpPost]
        public ActionResult CreateExpense(ExpenseAddDto expense)
        {
            if (_httpContextAccessor.HttpContext == null) return NotFound();
            var userId = StringConversion.ConvertToInt(_httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return _expenseService.AddExpense(expense.Date, userId)
                ? NoContent()
                : (ActionResult) BadRequest();
        }

        // DELETE api/expenses/{id}
        [Authorize(Policy = "LoggedUserOnly")]
        [HttpDelete("{id}")]
        public ActionResult DeleteExpense(int id)
        {
            if (_httpContextAccessor.HttpContext == null) return NotFound();
            var userId = StringConversion.ConvertToInt(_httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return _expenseService.DeleteExpense(id, userId)
                ? NoContent()
                : (ActionResult)BadRequest(new { message = "There is no expense with such id for this user" });
        }
    }
}
