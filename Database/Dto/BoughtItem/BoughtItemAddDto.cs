namespace Expension.Database.Dto.BoughtItem
{
    public class BoughtItemAddDto
    {
        public BoughtItemAddDto(int itemId, float price)
        {
            ItemId = itemId;
            Price = price;
        }

        public BoughtItemAddDto()
        {
        }

        public int ItemId { get; set; }
        public float Price { get; set; }
    }
}
