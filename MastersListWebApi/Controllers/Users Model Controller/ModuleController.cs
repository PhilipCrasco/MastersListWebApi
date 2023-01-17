using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.Interface.IServices;
using Microsoft.AspNetCore.Mvc;


namespace MastersListWebApi.Controllers.Users_Model_Controller
{

    public class ModuleController : BaseApiController
    {
        private readonly IUnitofWork _unitofWork;

        public ModuleController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }


        [HttpGet]
        [Route("GetAllActiveModule")]
        public async Task<IActionResult>  GetallActiveModule ()
        {
            var module = await _unitofWork.module.GetAllActiveModules();
            return Ok(module);
        }

        [HttpGet]
        [Route("GetAllInActiveModule")]
        public async Task<IActionResult> GetallInActiveModule()
        {
            var module = await _unitofWork.module.GetAllInActiveModules();
            return Ok(module);
        }

        [HttpPost]
        [Route ("AddNewModule")]
        public async Task<IActionResult> AddnewResult (Module module)
        {
            var validatemainmenuId = await _unitofWork.module.ValidMainmenuId(module.MainMenuId);

            if (validatemainmenuId == false)
                return BadRequest("No existing MainMenu Id");
            if (await _unitofWork.module.ExistModuleName(module.ModuleName))
                return BadRequest("Module Name was already existing");
            if (await _unitofWork.module.ExistSubMainMenuName(module.SubmenuName))
                return BadRequest("SubMain Menu Name was already existing");

           await _unitofWork.module.AddNewModule(module);
            await _unitofWork.CompleteAsync();
            return Ok(module);
        }

        [HttpPut]
        [Route("UpdateModule")]
        public async Task<IActionResult> Updatemodule (Module module)
        {
            var validatemainmenuId = await _unitofWork.module.ValidMainmenuId(module.MainMenuId);
            var validateModuleId = await _unitofWork.module.ValidateModuleId(module.Id);

            if (validateModuleId == false)
                return BadRequest("No Existing ModuleId");
            if (validatemainmenuId == false)
                return BadRequest("No existing MainMenu Id");
            if (await _unitofWork.module.ExistModuleName(module.ModuleName))
                return BadRequest("Module Name was already existing");
            if (await _unitofWork.module.ExistSubMainMenuName(module.SubmenuName))
                return BadRequest("SubMain Menu Name was already existing");

            await _unitofWork.module.UpdateModule(module);
            await _unitofWork.CompleteAsync();  
            return Ok(module);
        }

        [HttpPut]
        [Route("UpdateActiveModule")]
        public async Task<IActionResult> UpdateActivemodule(Module module)
        {
        
            var validateModuleId = await _unitofWork.module.ValidateModuleId(module.Id);

            if (validateModuleId == false)
                return BadRequest("No Existing ModuleId");

            await _unitofWork.module.UpdateActiveModule(module);
            await _unitofWork.CompleteAsync();
            return Ok(module);
        }


        [HttpPut]
        [Route("UpdateInActiveModule")]
        public async Task<IActionResult> UpdateInActivemodule(Module module)
        {

            var validateModuleId = await _unitofWork.module.ValidateModuleId(module.Id);

            if (validateModuleId == false)
                return BadRequest("No Existing ModuleId");

            await _unitofWork.module.UpdateInActiveModule(module);
            await _unitofWork.CompleteAsync();
            return Ok(module);
        }
    }
}
