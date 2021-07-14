using System;

namespace Expension.Database.Dto.Expense.IndividualExpense
{
    public class IndividualExpenseDisplayedDataDto
    {
        public IndividualExpenseDisplayedDataDto(DateTime shoppingDate, Models.BoughtItem boughtItem)
        {
            ShoppingDate = shoppingDate;
            BoughtItem = boughtItem;
        }

        public IndividualExpenseDisplayedDataDto()
        {

        }

        public DateTime ShoppingDate { get; }

        public Models.BoughtItem BoughtItem { get; }
    }
}
