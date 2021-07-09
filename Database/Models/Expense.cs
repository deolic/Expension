using System;
using System.ComponentModel.DataAnnotations;

namespace Expension.Database.Models
{
    public abstract class Expense
    {
        public int ExpenseId { get; set; }

        public DateTime ShoppingDate { get; set; }

        [Required]
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}