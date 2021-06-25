using System;

namespace Expension.Database.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public float Price { get; set; }

        public virtual User User { get; set; }

        public virtual Item Item { get; set; }
    }
}