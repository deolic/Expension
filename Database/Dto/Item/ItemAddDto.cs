namespace Expension.Database.Dto.Item
{
    public class ItemAddDto
    {
        public ItemAddDto(string name, string itemType)
        {
            Name = name;
            ItemType = itemType;
        }

        public ItemAddDto()
        {
        }

        public string Name { get; set; }

        public string ItemType { get; set; }

    }
}
