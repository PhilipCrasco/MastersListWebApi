using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Runtime.InteropServices;

namespace MastersListWebApi.Controllers.Users_Model_Controller
{

    public class UserController : BaseApiController
    {

        private readonly IUnitofWork _unitofwork;

        public UserController(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("GetallActiveUser")]
        public async Task<IActionResult> GetallactiveUsers ()
        {
            var user = await _unitofwork.user.GetAllActiveUsers();
            return Ok(user);
        }

        [HttpGet]
        [Route("GetallInActiveUser")]
        public async Task<IActionResult> GetallInactiveUsers()
        {
            var user = await _unitofwork.user.GetAllInActiveUsers();
            return Ok(user);
        }

        [HttpPost]
        [Route("AddnewUser")]
        public async Task<IActionResult> AddnewUser (Users user)
        {
            var ValidRoleId = await _unitofwork.user.ValidateRoleId(user.RolesId);
            var ValidDepartmentId = await _unitofwork.user.ValidateDepartmentId(user.DepartmentId);

            if (ValidRoleId == false)
                return BadRequest("No Valid Id");
            if (ValidDepartmentId == false)
                return BadRequest("No Valid Department Id");
            if (await _unitofwork.user.ExistingUsername(user.UserName))
                return BadRequest("The Username was Already existing");

            await _unitofwork.user.AddNewUsers(user);
            await _unitofwork.CompleteAsync();
            return Ok(user);    
            
        }

        [HttpPut]
        [Route("UpdateUsers")]
        public async Task<IActionResult> Updateusers (Users user)
        {
            var ValidRoleId = await _unitofwork.user.ValidateRoleId(user.RolesId);
            var ValidDepartmentId = await _unitofwork.user.ValidateDepartmentId(user.DepartmentId);
            var ValidUseerId = await _unitofwork.user.ValidateUserId(user.Id);

            if (ValidUseerId == false) 
                return BadRequest("No ValidId");
            if (ValidRoleId == false)
                return BadRequest("No Valid Id");
            if (ValidDepartmentId == false)
                return BadRequest("No Valid Department Id");
            if (await _unitofwork.user.ExistingUsername(user.UserName))
                return BadRequest("The Username was Already existing");


            await _unitofwork.user.UpdateUsers(user);
            await _unitofwork.CompleteAsync();  
            return Ok(user);


        }


        [HttpPut]
        [Route("UpdateActiveUsers")]
        public async Task<IActionResult> Updateactiveusers(Users user)
        {
            var ValidRoleId = await _unitofwork.user.ValidateRoleId(user.RolesId);
            var ValidDepartmentId = await _unitofwork.user.ValidateDepartmentId(user.DepartmentId);
            var ValidUseerId = await _unitofwork.user.ValidateUserId(user.Id);

            if (ValidUseerId == false)
                return BadRequest("No ValidId");
          


            await _unitofwork.user.UpdateActiveUsers(user);
            await _unitofwork.CompleteAsync();
            return Ok(user);


        }
        [HttpPut]
        [Route("UpdateInActiveUsers")]
        public async Task<IActionResult> UpdateaInctiveusers(Users user)
        {
            var ValidRoleId = await _unitofwork.user.ValidateRoleId(user.RolesId);
            var ValidDepartmentId = await _unitofwork.user.ValidateDepartmentId(user.DepartmentId);
            var ValidUseerId = await _unitofwork.user.ValidateUserId(user.Id);

            if (ValidUseerId == false)
                return BadRequest("No ValidId");



            await _unitofwork.user.UpdateInActiveUsers(user);
            await _unitofwork.CompleteAsync();
            return Ok(user);


        }


    }
}
