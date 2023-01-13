using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MastersListWebApi.Controllers.Users_Model_Controller
{

    public class RoleController : BaseApiController
    {
        private readonly IUnitofWork _unitofWork;


        public RoleController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [HttpGet]
        [Route("GetAllActiveRole")]
        public async Task<IActionResult> GetAllactiveRole()
        {
            var role = await _unitofWork.roles.GetAllActiveRoles();
            return Ok(role);

        }
        [HttpGet]
        [Route("GetAllInActiveRole")]
        public async Task<IActionResult> GetAllInactiveRole()
        {
            var role = await _unitofWork.roles.GetAllInActiveRoles();
            return Ok(role);

        }

        [HttpPost]
        [Route("AddNewRoles")]
        public async Task<IActionResult> Addnewrole(Roles roles)
        {

            if (await _unitofWork.roles.ValidationCodeName(roles.RoleName))
                return BadRequest("RoleName already exist");

            await _unitofWork.roles.AddNewRole(roles);
            await _unitofWork.CompleteAsync();
            return Ok(roles);
        }

        [HttpPut]
        [Route("UpdateRoles")]
        public async Task<IActionResult> Updateroles (Roles Role)
        { 
            var updateroles = await _unitofWork.roles.ValidationId(Role.Id);

            if(updateroles ==false)
            {
                return BadRequest("No existing Role Id");

            }
            if (await _unitofWork.roles.ValidationCodeName(Role.RoleName))
                return BadRequest("The RoleName is Already existing");

            await _unitofWork.roles.UpdateRoles(Role);
            await _unitofWork.CompleteAsync();
            return Ok(Role);

        }

        [HttpPut]
        [Route("UpdateActiveRoles")]
        public async Task<IActionResult> Updateactiveroles(Roles Role)
        {
           
            var updateroles = await _unitofWork.roles.ValidationId(Role.Id);

            if (updateroles == false)
            {
                return BadRequest("No existing Role Id");

            }

            await _unitofWork.roles.UpdateActiveRoles(Role);
            await _unitofWork.CompleteAsync();
            return Ok(Role);

        }

        [HttpPut]
        [Route("UpdateInActiveRoles")]
        public async Task<IActionResult> UpdateInactiveroles(Roles Role)
        {
           
            var updateroles = await _unitofWork.roles.ValidationId(Role.Id);

            if (updateroles == false)
            {
                return BadRequest("No existing Role Id");

            }

            await _unitofWork.roles.UpdateActiveRoles(Role);
            await _unitofWork.CompleteAsync();
            return Ok(Role);

        }



    }
}
