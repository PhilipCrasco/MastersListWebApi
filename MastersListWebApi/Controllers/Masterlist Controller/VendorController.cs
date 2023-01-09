using ClassLibrary.Interface.IServices;
using ClassLibrary.model;
using Microsoft.AspNetCore.Mvc;

namespace MastersListWebApi.Controllers
{

    public class VendorController : BaseApiController
    {
        private readonly IUnitofWork _unitofwork;

        public VendorController(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;   
        }

        [HttpGet]
        [Route("GetallActiveVendor")]
        public async Task<IActionResult> GetAllActiveVendors ()
        {
            var vendor = await _unitofwork.vendor.GetAllActiveVendor();
            return Ok(vendor);
        }
        [HttpGet]
        [Route("GetallInActiveVendor")]
        public async Task<IActionResult> GetAllInActiveVendors()
        {
            var vendor = await _unitofwork.vendor.GetAllInActiveVendor();
            return Ok(vendor);
        }

        [HttpPost]
        [Route("AddVendors")]

        public async Task<IActionResult> AddnewVendors(VendorName vendor)
        {
            if (await _unitofwork.vendor.VendorCodeValidation(vendor.VendorCode)) 
            return BadRequest("VendorCode already exist, Please try Another Input");
            if (await _unitofwork.vendor.VendorDescriptionValidation(vendor.VendorcodeName))
                return BadRequest("Vendor Description already exist Please Try it later");

            await _unitofwork.vendor.VendorAdd(vendor);
            await _unitofwork.CompleteAsync();
            return Ok(vendor);

        }

        [HttpPut]
        [Route("UpdateVendor")]
        
        public async Task<IActionResult> Updatevendor(VendorName vendor)
        {

            var updatevendor = await _unitofwork.vendor.UpdateVendor(vendor);

            if(updatevendor == false)
            {
                return BadRequest("Vendor Id Doesnt Exist. Please Try again");
            }
            if (await _unitofwork.vendor.VendorCodeValidation(vendor.VendorCode))
                return BadRequest("VendorCode already exist, Please try Another Input");
            if (await _unitofwork.vendor.VendorDescriptionValidation(vendor.VendorcodeName))
                return BadRequest("Vendor Description already exist Please Try it later");

            await _unitofwork.vendor.UpdateVendor(vendor);
            await _unitofwork.CompleteAsync();
            return Ok(vendor);


        }

        [HttpPut]
        [Route("UpdateActiveVendor")]

        public async Task<IActionResult> UpdateActivevendor(VendorName vendor)
        {

            var updatevendor = await _unitofwork.vendor.VendorActiveVendor(vendor);

            if (updatevendor == false)
            {
                return BadRequest("Vendor Id Doesnt Exist. Please Try again");
            }
          

            await _unitofwork.vendor.VendorActiveVendor(vendor);
            await _unitofwork.CompleteAsync();
            return Ok(vendor);


        }

        [HttpPut]
        [Route("UpdateInActiveVendor")]

        public async Task<IActionResult> UpdateInActivevendor(VendorName vendor)
        {

            var updatevendor = await _unitofwork.vendor.VendorInActive(vendor);

            if (updatevendor == false)
            {
                return BadRequest("Vendor Id Doesnt Exist. Please Try again");
            }


            await _unitofwork.vendor.VendorInActive(vendor);
            await _unitofwork.CompleteAsync();
            return Ok(vendor);


        }






    }
}
