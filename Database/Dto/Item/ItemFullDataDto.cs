namespace Expension.Database.Dto.Item
{
    public class ItemFullDataDtoDto
    {
        public ItemFullDataDtoDto(int id, string name, string itemType)
        {
            ItemId = id;
            Name = name;
            ItemType = itemType;
        }

        public ItemFullDataDtoDto()
        {
        }
        public int ItemId { get; set; }

        public string Name { get; set; }

        public string ItemType { get; set; }

    }
}
