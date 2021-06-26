using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Expension.Database.Models
{
    public class Shopping
    {
        public int ShoppingId { get; set; }

        public float SpentMoney { get; set; }

        public DateTime ShoppingDate { get; set; }

        [Required]
        public virtual User User { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
