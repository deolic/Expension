using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expension.Database.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}