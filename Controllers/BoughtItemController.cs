using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Expension.Database.Dto.BoughtItem;
using Expension.Services.BoughtItem;

namespace Expension.Controllers
{
    [Route("api/bought-items")]
    [ApiController]
    public class BoughtItemController : ControllerBase
    {
        private readonly IBoughtItemService _boughtItemService;
        public BoughtItemController(IBoughtItemService boughtItemService)
        {
            _boughtItemService = boughtItemService;
        }

        // GET: api/bought-items
        [HttpGet]
        public ActionResult<List<BoughtItemFullDataDto>> GetAllBoughtItems()
        {
            return _boughtItemService.GetBoughtItems();
        }

        // GET: api/bought-items/{id}
        [HttpGet("{id}")]
        public ActionResult<BoughtItemFullDataDto> GetBoughtItem(int id)
        {
            var boughtItem = _boughtItemService.GetBoughtItemById(id);
            return boughtItem != null ? (ActionResult<BoughtItemFullDataDto>) boughtItem : NotFound(new { message = "There is no bought item with such id"});
        }

        // POST: api/bought-items/{type}
        [HttpPost("{type}")]
        public ActionResult PostBoughtItem(BoughtItemAddDto boughtItem, string type)
        {
            return _boughtItemService.AddBoughtItem(boughtItem, type)
                ? NoContent()
                : (ActionResult) BadRequest(new {message = "Wrong type of expense" });
        }

        // DELETE: api/bought-items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBoughtItem(int id)
        {
            return _boughtItemService.DeleteBoughtItem(id) ? NoContent() : (ActionResult) BadRequest(new { message = "There is no bought item with such id" });
        }
    }
}
