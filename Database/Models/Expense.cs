using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expension.Database.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public DateTime ShoppingDate { get; set; }

        [Required]
        public virtual User User { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<BoughtItem> BoughtItems { get; set; }
    }
}