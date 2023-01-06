using ClassLibrary.Interface.IServices;
using ClassLibrary.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace MastersListWebApi.Controllers.Masterlist_Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OumController : ControllerBase
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

          var oum = await _unitofwork.oums.GetAllInActiveUom();
            return Ok(oum);

        }

        [HttpGet]
        [Route("GetAllInActiveUom")]
        public async Task<IActionResult> GetAllInActiveUoms()
        {

            var oum = await _unitofwork.oums.GetAllInActiveUom();
            return Ok(oum);

        }








    }
}
