using System.ComponentModel.DataAnnotations;

namespace Expension.Database.Models
{
    public class BoughtItem
    {
        public int BoughtItemId { get; set; }

        [Required]
        public Item Item { get; set; }
        public int ItemId { get; set; }

        public float Price { get; set; }

        public Shopping Shopping { get; set; }
        public int? ShoppingId { get; set; }

        public IndividualExpense IndividualExpense { get; set; }
        public int? IndividualExpenseId { get; set; }
    }
}
