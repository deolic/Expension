namespace Expension.Database.Dto.BoughtItem
{
    public class BoughtItemFullDataDto
    {
        public BoughtItemFullDataDto(int boughtItemId, int itemId, float price)
        {
            BoughtItemId = boughtItemId;
            ItemId = itemId;
            Price = price;
        }

        public BoughtItemFullDataDto()
        {
        }

        public int BoughtItemId { get; set; }
        public int ItemId { get; set; }
        public float Price { get; set; }
    }
}
