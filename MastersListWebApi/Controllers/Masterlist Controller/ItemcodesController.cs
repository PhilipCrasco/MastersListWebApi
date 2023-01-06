using ClassLibrary.Interface.IServices;
using ClassLibrary.Persistence;
using ClassLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MastersListWebApi.Controllers.Masterlist_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemcodesController : ControllerBase
    {
        private readonly IUnitofWork _unitofwork;

        public ItemcodesController(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;

        }

        [HttpGet]
        [Route("GetallactiveItemCodes")]
        public async Task <IActionResult > GetAllActiveItems ()
        {
            var Items = await _unitofwork.itemCodes.GetAllActiveItem();
            return Ok(Items);
        }



        [HttpGet]
        [Route("GetallInactiveItemCodes")]
        public async Task<IActionResult> GetAllInActiveItems()
        {
            var Items = await _unitofwork.itemCodes.GetAllActiveItem();
            return Ok(Items);
        }

    }
}
