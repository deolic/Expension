using System;
using System.Collections.Generic;
using Expension.Database.Dto.BoughtItem;

namespace Expension.Database.Dto.Expense
{
    public class ExpenseDisplayedDataDto
    {
        public ExpenseDisplayedDataDto(int expenseId, DateTime date, ICollection<BoughtItemDisplayedDto> boughtItems)
        {
            ExpenseId = expenseId;
            Date = date;
            BoughtItems = boughtItems;
        }

        public ExpenseDisplayedDataDto()
        {

        }
        public int ExpenseId { get; set; }

        public DateTime Date { get; set; }

        public ICollection<BoughtItemDisplayedDto> BoughtItems { get; set; }
    }
}
