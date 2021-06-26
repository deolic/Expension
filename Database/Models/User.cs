using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expension.Database.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Shopping> Shoppings { get; set; }
    }
}