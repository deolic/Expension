using System.Collections.Generic;
using Expension.Database.Dto.Item;

namespace Expension.Services.Item
{
    public interface IItemService
    {
        List<ItemFullDataDtoDto> GetItems();
        ItemFullDataDtoDto GetItemById(int id);
        bool AddItem(ItemAddDto item);
        bool DeleteItem(int id);
    }
}
