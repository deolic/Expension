using System;
using System.ComponentModel.DataAnnotations;

namespace Expension.Database.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public float Price { get; set; }

        [Required]
        public virtual Shopping Shopping { get; set; }

        [Required]
        public virtual Item Item { get; set; }
    }
}