using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expension.Database.Dto.Item;
using Expension.Database.Repositories.Item;

namespace Expension.Services.Item
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository) 
        {
            _itemRepository = itemRepository;
        }

        public List<ItemFullDataDtoDto> GetItems()
        {
            var items = _itemRepository.FindAll().Select(i => new ItemFullDataDtoDto
            {
                ItemId = i.ItemId,
                Name = i.Name,
                ItemType = i.ItemType
            }).ToList();
            return items;
        }

        public bool AddItem(ItemAddDto itemData)
        {
            if(_itemRepository.FindSingleByCondition(i => i.Name == itemData.Name && i.ItemType == itemData.ItemType) != null)
            {
                return false;
            }
            var item = new Database.Models.Item
            {
                Name = itemData.Name,
                ItemType = itemData.ItemType
            };
            _itemRepository.Create(item);
            _itemRepository.Save();
            return true;
        }

        public bool DeleteItem(int id)
        {
            var item = _itemRepository.FindSingleByCondition(i => i.ItemId == id);
            if (item == null)
            {
                return false;
            }
            _itemRepository.Delete(item);
            _itemRepository.Save();
            return true;
        }

        public ItemFullDataDtoDto GetItemById(int id)
        {
            var item = _itemRepository.FindSingleByCondition(i => i.ItemId == id);
            if (item == null)
            {
                return null;
            }
            return new ItemFullDataDtoDto
            {
                ItemId = item.ItemId,
                Name = item.Name,
                ItemType = item.ItemType
            };
        }
    }
}
