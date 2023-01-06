using ClassLibrary.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MastersListWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
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

       



    }
}
