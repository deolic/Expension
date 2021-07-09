using System.Collections.Generic;

namespace Expension.Database.Models
{
    public class Shopping : Expense
    {
        public virtual ICollection<BoughtItem> BoughtItems { get; set; }
    }
}
