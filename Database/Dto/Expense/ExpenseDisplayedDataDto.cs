using System;
using System.Collections.Generic;
using Expension.Database.Dto.BoughtItem;

namespace Expension.Database.Dto.Expense
{
    public class ExpenseDisplayedDataDto
    {
        public ExpenseDisplayedDataDto(DateTime date, ICollection<BoughtItemDisplayedDto> boughtItems)
        {
            Date = date;
            BoughtItems = boughtItems;
        }

        public ExpenseDisplayedDataDto()
        {

        }

        public DateTime Date { get; set; }

        public ICollection<BoughtItemDisplayedDto> BoughtItems { get; set; }
    }
}
