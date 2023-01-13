using ClassLibrary.Interface.IServices;
using ClassLibrary.model.Masterlist;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace MastersListWebApi.Controllers.Masterlist_Controller
{

    public class ItemcodesController : BaseApiController
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
            var Items = await _unitofwork.itemCodes.GetAllInActiveItem();
            return Ok(Items);
        }

        [HttpPost]
        [Route("AddNewItemCode")]

        public async Task<IActionResult> Addnewitemcodes(ItemCode item)
        {
            var itemcodeuomid = await _unitofwork.itemCodes.ValidateUomId(item.UomId);
            var itemcodeItemCategory = await _unitofwork.itemCodes.ValidateItemCategoryId(item.ItemCategoryId);
            if( itemcodeItemCategory == false)
            {
                return BadRequest("The ItemCategoryId Doesnt Exist");
            }

            if (itemcodeuomid == false)
            {
                return BadRequest("The UomId doesn't exist");

            }
            if (await _unitofwork.itemCodes.ValidateCodeExist(item.ItemCodes))
                return BadRequest("ItemCode Already Exist!, Try something else");

            await _unitofwork.itemCodes.AddItem(item);
            await _unitofwork.CompleteAsync();
            return Ok(item);
            
        }

        [HttpPut]
        [Route("UpdateItem")]

        public async Task<IActionResult> Updateitem([FromBody] ItemCode itemCode)
        {
            var validateItemid = await _unitofwork.itemCodes.UpdateItemCode(itemCode);
            var validdateUomId = await _unitofwork.itemCodes.ValidateUomId(itemCode.UomId);

            if (validateItemid == false)
            {
                return BadRequest("The id Doesnt Exist, Please Try Again");
            }

            if (validdateUomId == false)
            {
                return BadRequest("The UomId Doesnt Exist, Please Try Again");
            }



            if (await _unitofwork.itemCodes.ValidateCodeExist(itemCode.ItemCodes))
                return BadRequest("ItemCode Already Exist!, Try something else");

            await _unitofwork.itemCodes.UpdateItemCode(itemCode);
            await _unitofwork.CompleteAsync();
            return Ok(itemCode);

        }

        [HttpPut]
        [Route("UpdateActiveItem")]

        public async Task<IActionResult> UpdateActiveitem([FromBody] ItemCode itemCode)
        {
            var validateItemid = await _unitofwork.itemCodes.UpdateActiveItem(itemCode);
         

            if (validateItemid == false)
            {
                return BadRequest("The id Doesnt Exist, Please Try Again");
            }



            await _unitofwork.itemCodes.UpdateActiveItem(itemCode);
            await _unitofwork.CompleteAsync();
            return Ok(itemCode);

        }
        [HttpPut]
        [Route("UpdateInActiveItem")]

        public async Task<IActionResult> UpdateInActiveitem([FromBody] ItemCode itemCode)
        {
            var validateItemid = await _unitofwork.itemCodes.UpdateInActive(itemCode);


            if (validateItemid == false)
            {
                return BadRequest("The id Doesnt Exist, Please Try Again");
            }



            await _unitofwork.itemCodes.UpdateInActive(itemCode);
            await _unitofwork.CompleteAsync();
            return Ok(itemCode);

        }





    }
}
