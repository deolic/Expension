using System;

namespace Expension.Database.Dto.Expense
{
    public class ExpenseAddDto
    {
        public ExpenseAddDto(DateTime shoppingDate, int userId)
        {
            ShoppingDate = shoppingDate;
            UserId = userId;
        }

        public ExpenseAddDto()
        {

        }

        public DateTime ShoppingDate { get; set; }

        public int UserId { get; set; }
    }
}
