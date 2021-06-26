using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expension.Database.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ItemType { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}