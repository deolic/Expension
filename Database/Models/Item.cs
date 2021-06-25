using System.Collections.Generic;

namespace Expension.Database.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public string ItemType { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}