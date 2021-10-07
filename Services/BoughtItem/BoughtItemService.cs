using System.Collections.Generic;
using System.Linq;
using Expension.Database.Dto.BoughtItem;
using Expension.Database.Repositories.BoughtItem;

namespace Expension.Services.BoughtItem
{
    public class BoughtItemService : IBoughtItemService
    {
        private readonly IBoughtItemRepository _boughtItemRepository;

        public BoughtItemService(IBoughtItemRepository boughtItemRepository)
        {
            _boughtItemRepository = boughtItemRepository;
        }

        public List<BoughtItemFullDataDto> GetBoughtItems()
        {
            var boughtItems = _boughtItemRepository.FindAll().Select(bi => new BoughtItemFullDataDto(
                bi.BoughtItemId, bi.ItemId, bi.Price, bi.ExpenseId)).ToList();
            return boughtItems;
        }

        public BoughtItemFullDataDto GetBoughtItemById(int id)
        {
            var boughtItem = _boughtItemRepository.FindSingleByCondition(bi => bi.BoughtItemId == id);
            return boughtItem == null
                ? null
                : new BoughtItemFullDataDto(boughtItem.BoughtItemId, boughtItem.ItemId, boughtItem.Price,
                    boughtItem.ExpenseId);
        }

        public bool AddBoughtItem(BoughtItemAddDto boughtItemData)
        {
            var boughtItem = new Database.Models.BoughtItem
            {
                ItemId = boughtItemData.ItemId,
                Price = boughtItemData.Price,
                ExpenseId = boughtItemData.ExpenseId
            };
            _boughtItemRepository.Create(boughtItem);
            _boughtItemRepository.Save();
            return true;
        }

        public bool DeleteBoughtItem(int id, int userId)
        {
            var boughtItem = _boughtItemRepository.FindSingleByCondition(bi => bi.BoughtItemId == id && bi.Expense.UserId == userId);
            if (boughtItem == null)
            {
                return false;
            }
            _boughtItemRepository.Delete(boughtItem);
            _boughtItemRepository.Save();
            return true;
        }
    }
}
