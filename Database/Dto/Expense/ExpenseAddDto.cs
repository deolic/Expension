using System;

namespace Expension.Database.Dto.Expense
{
    public class ExpenseAddDto
    {
        public ExpenseAddDto(DateTime shoppingDate)
        {
            ShoppingDate = shoppingDate;
        }

        public ExpenseAddDto()
        {

        }

        public DateTime ShoppingDate { get; set; }
    }
}