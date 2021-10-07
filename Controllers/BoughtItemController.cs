using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Expension.Database.Dto.BoughtItem;
using Expension.Services.BoughtItem;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public ActionResult<List<BoughtItemFullDataDto>> GetAllBoughtItems()
        {
            return _boughtItemService.GetBoughtItems();
        }

        // GET: api/bought-items/{id}
        [Authorize(Policy = "LoggedUserOnly")]
        [HttpGet("{id}")]
        public ActionResult<BoughtItemFullDataDto> GetBoughtItem(int id)
        {
            var boughtItem = _boughtItemService.GetBoughtItemById(id);
            return boughtItem != null ? (ActionResult<BoughtItemFullDataDto>) boughtItem : NotFound(new { message = "There is no bought item with such id"});
        }

        // POST: api/bought-items/
        [Authorize(Policy = "LoggedUserOnly")]
        [HttpPost]
        public ActionResult PostBoughtItem(BoughtItemAddDto boughtItem)
        {
            return _boughtItemService.AddBoughtItem(boughtItem)
                ? NoContent()
                : (ActionResult) BadRequest();
        }

        // DELETE: api/bought-items/{id}
        [Authorize(Policy = "LoggedUserOnly")]
        [HttpDelete("{id}")]
        public ActionResult DeleteBoughtItem(int id)
        {
            return _boughtItemService.DeleteBoughtItem(id) ? NoContent() : (ActionResult) BadRequest(new { message = "There is no bought item with such id" });
        }
    }
}
