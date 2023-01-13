using ClassLibrary.Data_Acess_Layer.model.Masterlist;
using ClassLibrary.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MastersListWebApi.Controllers.Masterlist_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IUnitofWork _unitofwork;

        public ItemCategoryController(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpPost]
        [Route("AddnewItemCategory")]
        public async Task<IActionResult> AddItemCategory(ItemCategory itemCategory)
        {

            if( await _unitofwork.ItemCategory.ValidatedCategoryName(itemCategory.ItemCategoryName))
                return BadRequest("ItemCategory Name Was Already Exist");

            await _unitofwork.ItemCategory.AddnewItemCategory(itemCategory);
            await _unitofwork.CompleteAsync();
            return Ok(itemCategory);

            
        }

        [HttpGet]
        [Route("GetAllActiveItemcategory")]

        public async Task<IActionResult> GetAllactiveItemCategrory()
        {

            var itemCate = await _unitofwork.ItemCategory.GetAllActiveItemCategory();
                
                return Ok(itemCate);
            
        }

        [HttpGet]
        [Route("GetAllInActiveItemcategory")]

        public async Task<IActionResult> GetAllInactiveItemCategrory()
        {

            var itemCate = await _unitofwork.ItemCategory.GetAllInActiveItemCategory();

            return Ok(itemCate);

        }

        [HttpPut]
        [Route("UpdateItemCategory")]
        public async Task<IActionResult> UpdateItemCateg(ItemCategory itemCategory)
        {
            var validateitemcategId =    await _unitofwork.ItemCategory.UpdateItemCategory(itemCategory);

            if (validateitemcategId == false)
                return BadRequest("No ItemCategory Id is existed");
            if (await _unitofwork.ItemCategory.ValidatedCategoryName(itemCategory.ItemCategoryName))
                return BadRequest("ItemCategory Name Was Already Exist");


            await _unitofwork.ItemCategory.UpdateItemCategory(itemCategory);
            await _unitofwork.CompleteAsync();
            return Ok(itemCategory);
        }
        [HttpPut]
        [Route("UpdateActiveItemCategory")]
        public async Task<IActionResult> UpdateActiveItemCateg(ItemCategory itemCategory)
        {
            var validateitemcategId = await _unitofwork.ItemCategory.UpdateActiveItemCategory(itemCategory);

            if (validateitemcategId == false)
                return BadRequest("No ItemCategory Id is existed");
            if (await _unitofwork.ItemCategory.ValidatedCategoryName(itemCategory.ItemCategoryName))
                return BadRequest("ItemCategory Name Was Already Exist");


            await _unitofwork.ItemCategory.UpdateActiveItemCategory(itemCategory);
            await _unitofwork.CompleteAsync();
            return Ok(itemCategory);
        }
        [HttpPut]
        [Route("UpdateInActiveItemCategory")]
        public async Task<IActionResult> UpdateInActiveItemCateg(ItemCategory itemCategory)
        {
            var validateitemcategId = await _unitofwork.ItemCategory.UpdateInActiveItemCategory(itemCategory);

            if (validateitemcategId == false)
                return BadRequest("No ItemCategory Id is existed");
            if (await _unitofwork.ItemCategory.ValidatedCategoryName(itemCategory.ItemCategoryName))
                return BadRequest("ItemCategory Name Was Already Exist");


            await _unitofwork.ItemCategory.UpdateInActiveItemCategory(itemCategory);
            await _unitofwork.CompleteAsync();
            return Ok(itemCategory);
        }





    }
}
