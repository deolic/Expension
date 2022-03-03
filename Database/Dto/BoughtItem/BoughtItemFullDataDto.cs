namespace Expension.Database.Dto.BoughtItem
{
    public class BoughtItemFullDataDto
    {
        public BoughtItemFullDataDto(int boughtItemId, int itemId, float price, int expenseId)
        {
            BoughtItemId = boughtItemId;
            ItemId = itemId;
            Price = price;
            ExpenseId = expenseId;
        }

        public BoughtItemFullDataDto()
        {
        }

        public int BoughtItemId { get; set; }
        public int ItemId { get; set; }
        public float Price { get; set; }
        public int ExpenseId { get; set; }
    }
}
