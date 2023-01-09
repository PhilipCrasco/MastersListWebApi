using ClassLibrary.Interface.IServices;
using ClassLibrary.model.Masterlist;
using Microsoft.AspNetCore.Mvc;

namespace MastersListWebApi.Controllers.Masterlist_Controller
{

    public class OumController : BaseApiController
    {

        private readonly IUnitofWork _unitofwork;

        public OumController(IUnitofWork unitofWork)
        {
           _unitofwork= unitofWork;
        }

        [HttpGet]
        [Route("GetAllActiveUom")]
        public async Task<IActionResult> GetAllActiveUoms()
        {

          var oum = await _unitofwork.oums.GetAllActiveUom();
            return Ok(oum);

        }

        [HttpGet]
        [Route("GetAllInActiveUom")]
        public async Task<IActionResult> GetAllInActiveUoms()
        {

            var oum = await _unitofwork.oums.GetAllInActiveUom();
            return Ok(oum);

        }

        [HttpPost]
        [Route("AddNewUom")]

        public async Task<IActionResult> AddnewUoms(Uom uoms)
        {
            if (await _unitofwork.oums.ItemCodeExist(uoms.UomCode)) 
            return BadRequest("The UomCode already existed, Please try another input");

            if (await _unitofwork.oums.ValidateUomDescription(uoms.UomDescription))
                return BadRequest("Uom Description already exist please Try again");

            await _unitofwork.oums.AddUom(uoms);
            await _unitofwork.CompleteAsync();
            return Ok(uoms);
        }

        [HttpPut]
        [Route("UpdateUom")]

        public async Task<IActionResult>UpdateUOM (Uom uom)
        {
            var updateUom = await _unitofwork.oums.UpdateUom(uom);

            if (updateUom == false)
            {
                return BadRequest("No existing UomId Please Try Again");
            }
            if (await _unitofwork.oums.ItemCodeExist(uom.UomCode))
                return BadRequest("The UomCode already existed, Please try another input");

            if (await _unitofwork.oums.ValidateUomDescription(uom.UomDescription))
                return BadRequest("Uom Description already exist please Try again");

            await _unitofwork.oums.UpdateUom(uom);
            await _unitofwork.CompleteAsync();
            return Ok(uom);
        }

        [HttpPut]
        [Route("UpdateActiveUom")]

        public async Task<IActionResult> UpdateActiveUOM(Uom uom)
        {
            var updateUom = await _unitofwork.oums.UpdateActiveUom(uom);

            if (updateUom == false)
            {
                return BadRequest("No existing UomId Please Try Again");
            }


            await _unitofwork.oums.UpdateActiveUom(uom);
            await _unitofwork.CompleteAsync();
            return Ok(uom);
        }

        [HttpPut]
        [Route("UpdateInActiveUom")]

        public async Task<IActionResult> UpdateInActiveUOM(Uom uom)
        {
            var updateUom = await _unitofwork.oums.UpdateInActiveUom(uom);

            if (updateUom == false)
            {
                return BadRequest("No existing UomId Please Try Again");
            }


            await _unitofwork.oums.UpdateInActiveUom(uom);
            await _unitofwork.CompleteAsync();
            return Ok(uom);
        }





    }
}
