using Expension.Database.Dto.Item;

namespace Expension.Database.Dto.BoughtItem
{
    public class BoughtItemDisplayedDto
    {
        public BoughtItemDisplayedDto(float price, ItemDisplayedDto item)
        {
            Price = price;
            Name = item.Name;
            ItemType = item.ItemType;
        }

        public BoughtItemDisplayedDto()
        {
        }

        public float Price { get; set; }
        public string Name { get; set; }
        public string ItemType { get; set; }
    }
}
