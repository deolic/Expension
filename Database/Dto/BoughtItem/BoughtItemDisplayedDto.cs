using Expension.Database.Dto.Item;

namespace Expension.Database.Dto.BoughtItem
{
    public class BoughtItemDisplayedDto
    {
        public BoughtItemDisplayedDto(int boughtItemId, float price, ItemDisplayedDto item)
        {
            BoughtItemId = boughtItemId;
            Price = price;
            Name = item.Name;
            ItemType = item.ItemType;
        }

        public BoughtItemDisplayedDto()
        {
        }
        public int BoughtItemId { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string ItemType { get; set; }
    }
}
