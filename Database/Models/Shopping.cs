using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expension.Database.Models
{
    public class Shopping
    {
        public int ShoppingId { get; set; }

        public float Price { get; set; }

        public DateTime ShoppingDate { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
