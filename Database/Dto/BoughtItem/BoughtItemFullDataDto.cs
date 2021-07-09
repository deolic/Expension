namespace Expension.Database.Dto.BoughtItem
{
    public class BoughtItemFullDataDto
    {
        public BoughtItemFullDataDto(int boughtItemId, int itemId, float price, int? shoppingId, int? individualExpenseId)
        {
            BoughtItemId = boughtItemId;
            ItemId = itemId;
            Price = price;
            ShoppingId = shoppingId;
            IndividualExpenseId = individualExpenseId;
        }

        public BoughtItemFullDataDto()
        {
        }

        public int BoughtItemId { get; set; }
        public int ItemId { get; set; }
        public float Price { get; set; }
        public int? ShoppingId { get; set; }
        public int? IndividualExpenseId { get; set; }
    }
}
