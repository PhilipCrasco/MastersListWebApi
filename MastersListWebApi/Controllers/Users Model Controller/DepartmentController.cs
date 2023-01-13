using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MastersListWebApi.Controllers.Users_Model_Controller
{

    public class DepartmentController : BaseApiController
    {
        private readonly IUnitofWork _unitofwork;

        public DepartmentController(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("GetAllActiveDepartment")]
        public async Task<IActionResult> GetallactiverDepartment()
        {
            var department = await _unitofwork.department.GetAllActiveDepartment();
            return Ok(department);
        }
        [HttpGet]
        [Route("GetInAllActiveDepartment")]
        public async Task<IActionResult> GetallInactiverDepartment()
        {
            var department = await _unitofwork.department.GetAllInActiveDepartment();
            return Ok(department);
        }

        [HttpPost]
        [Route("AddnewDepartment")]
        public async Task<IActionResult> AddnewDepartment (Department department)
        {
          
            if (await _unitofwork.department.ValidateDepartmentCode(department.DepartmentCode))
                return BadRequest("The Department Code was Already exist");

            await _unitofwork.department.AddnewDapartment(department);
            await _unitofwork.CompleteAsync();
            return Ok(department);
        }


    }
}
