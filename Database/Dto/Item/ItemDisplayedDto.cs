namespace Expension.Database.Dto.Item
{
    public class ItemDisplayedDto
    {
        public ItemDisplayedDto(string name, string itemType)
        {
            Name = name;
            ItemType = itemType;
        }

        public ItemDisplayedDto()
        {
        }

        public string Name { get; set; }

        public string ItemType { get; set; }
    }
}
