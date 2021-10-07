using System;

namespace Expension.Database.Dto.Expense
{
    public class ExpenseAddDto
    {
        public ExpenseAddDto(DateTime date)
        {
            Date = date;
        }

        public ExpenseAddDto()
        {

        }

        public DateTime Date { get; set; }
    }
}