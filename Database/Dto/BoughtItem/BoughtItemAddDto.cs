namespace Expension.Database.Dto.BoughtItem
{
    public class BoughtItemAddDto
    {
        public BoughtItemAddDto(int itemId, float price, int expenseId)
        {
            ItemId = itemId;
            Price = price;
            ExpenseId = expenseId;
        }

        public BoughtItemAddDto()
        {
        }

        public int ItemId { get; set; }
        public float Price { get; set; }
        public int ExpenseId { get; set; }
    }
}
