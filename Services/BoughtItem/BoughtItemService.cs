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
            var boughtItems = _boughtItemRepository.FindAll().Select(bi => new BoughtItemFullDataDto
            {
                BoughtItemId = bi.BoughtItemId,
                ItemId = bi.ItemId,
                Price = bi.Price,
                IndividualExpenseId = bi.IndividualExpenseId,
                ShoppingId = bi.ShoppingId
            }).ToList();
            return boughtItems;
        }

        public BoughtItemFullDataDto GetBoughtItemById(int id)
        {
            var boughtItem = _boughtItemRepository.FindSingleByCondition(bi => bi.BoughtItemId == id);
            if (boughtItem == null)
            {
                return null;
            }

            return new BoughtItemFullDataDto
            {
                BoughtItemId = boughtItem.BoughtItemId,
                ItemId = boughtItem.ItemId,
                Price = boughtItem.Price,
                IndividualExpenseId = boughtItem.IndividualExpenseId,
                ShoppingId = boughtItem.ShoppingId
            };
        }

        public bool AddBoughtItem(BoughtItemAddDto boughtItemData, string type)
        {
            Database.Models.BoughtItem boughtItem;
            switch (type)
            {
                case "individual":
                    boughtItem = new Database.Models.BoughtItem
                    {
                        ItemId = boughtItemData.ItemId,
                        Price = boughtItemData.Price,
                        IndividualExpenseId = boughtItemData.ExpenseId
                    };
                    break;
                case "shopping":

                    boughtItem = new Database.Models.BoughtItem
                    {
                        ItemId = boughtItemData.ItemId,
                        Price = boughtItemData.Price,
                        ShoppingId = boughtItemData.ExpenseId
                    };
                    break;
                default:
                    return false;
            }
            _boughtItemRepository.Create(boughtItem);
            _boughtItemRepository.Save();
            return true;
        }

        public bool DeleteBoughtItem(int id)
        {
            var boughtItem = _boughtItemRepository.FindSingleByCondition(bi => bi.BoughtItemId == id);
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
