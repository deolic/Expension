using System;
using System.Collections.Generic;

namespace Expension.Database.Dto.Expense.Shopping
{
    public class ShoppingDisplayedDataDto
    {
        public ShoppingDisplayedDataDto( DateTime shoppingDate, ICollection<Models.BoughtItem> boughtItems)
        {
            ShoppingDate = shoppingDate;
            BoughtItems = boughtItems;
        }

        public ShoppingDisplayedDataDto()
        {

        }

        public DateTime ShoppingDate { get; }

        public ICollection<Models.BoughtItem> BoughtItems { get; }
    }
}
