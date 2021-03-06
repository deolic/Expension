using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Expension.Database.Dto.Item;
using Expension.Services.Item;
using Microsoft.AspNetCore.Authorization;

namespace Expension.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/items
        [HttpGet]
        public ActionResult<List<ItemFullDataDtoDto>> GetAllItems()
        {
            return _itemService.GetItems();
        }

        // GET: api/items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemFullDataDtoDto> GetItem(int id)
        {
            var item = _itemService.GetItemById(id);
            return item != null ? (ActionResult<ItemFullDataDtoDto>) item : NotFound(new { message = "There is no item with such id"});
        }

        // POST: api/items
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public ActionResult PostItem(ItemAddDto item)
        {
            return _itemService.AddItem(item) ? NoContent() : (ActionResult)BadRequest(new { message = "There already is an item with such name and type" });
        }

        // DELETE: api/items/{id}
        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            return _itemService.DeleteItem(id) ? NoContent() : (ActionResult) BadRequest(new {message = "There is no item with such id" });
        }
    }
}
