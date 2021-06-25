using System.Collections.Generic;

namespace Expension.Database.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}