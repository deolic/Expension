﻿namespace Expension.Database.Models
{
    public class IndividualExpense : Expense
    {
        public virtual BoughtItem BoughtItem { get; set; }
        public int? BoughtItemId { get; set; }
    }
}
