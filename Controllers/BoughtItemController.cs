using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Expension.Database.Dto.BoughtItem;
using Expension.Services.BoughtItem;
using Expension.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Expension.Controllers
{
    [Route("api/bought-items")]
    [ApiController]
    public class BoughtItemController : ControllerBase
    {
        private readonly IBoughtItemService _boughtItemService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BoughtItemController(IBoughtItemService boughtItemService, IHttpContextAccessor httpContextAccessor)
        {
            _boughtItemService = boughtItemService;
            _httpContextAccessor = httpContextAccessor;
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
                : (ActionResult) BadRequest(new { message = "Wrong expense id or there is no expense with such id for this user" });
        }

        // DELETE: api/bought-items/{id}
        [Authorize(Policy = "LoggedUserOnly")]
        [HttpDelete("{id}")]
        public ActionResult DeleteBoughtItem(int id)
        {
            if (_httpContextAccessor.HttpContext == null) return NotFound();
            var userId = StringConversion.ConvertToInt(_httpContextAccessor.HttpContext.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return _boughtItemService.DeleteBoughtItem(id, userId) ? NoContent() : (ActionResult) BadRequest(new { message = "There is no bought item with such id for this user" });
        }
    }
}
