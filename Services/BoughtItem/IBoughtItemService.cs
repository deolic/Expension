using System.Collections.Generic;
using Expension.Database.Dto.BoughtItem;

namespace Expension.Services.BoughtItem
{
    public interface IBoughtItemService
    {
        List<BoughtItemFullDataDto> GetBoughtItems();

        BoughtItemFullDataDto GetBoughtItemById(int id);

        bool AddBoughtItem(BoughtItemAddDto item, string type);

        bool DeleteBoughtItem(int id);
    }
}
