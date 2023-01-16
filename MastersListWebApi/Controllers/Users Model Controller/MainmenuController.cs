using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.Interface.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace MastersListWebApi.Controllers.Users_Model_Controller
{
  
    public class MainmenuController : BaseApiController
    {
        private readonly IUnitofWork _unitofwork;

        public MainmenuController(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        [Route("GetAllActiverMainmenu")]
        public async Task<IActionResult> GetAllActivemainment()
        {
           var mainmenu = await _unitofwork.mainmenu.GetAllActiveMainmenu();
            return Ok(mainmenu);    
        }

        [HttpGet]
        [Route("GetAllInActiverMainmenu")]
        public async Task<IActionResult> GetAllInActivemainment()
        {
            var mainmenu = await _unitofwork.mainmenu.GetAllInActiveMainmenu();
            return Ok(mainmenu);
        }

        [HttpPost]
        [Route("AddNewMainmenu")]
        public async Task<IActionResult> Addnewmainmenu (MainMenu main)
        {
            if (await _unitofwork.mainmenu.ExistModuleName(main.ModuleName))
                return BadRequest("ModuleName was already existing");

            await _unitofwork.mainmenu.AddNewMainmenu(main);
            await _unitofwork.CompleteAsync();
            return Ok(main);
        }

        [HttpPut]
        [Route("UpdateMainmenu")]
        public async Task<IActionResult> Updatemainmenu (MainMenu main)
        {
            var validateId = await _unitofwork.mainmenu.ValidatemainmenuId(main.Id);

            if (validateId == false)
                return BadRequest("Mainmenu Id is nut existing");
            if(await _unitofwork.mainmenu.ExistModuleName(main.ModuleName))
                return BadRequest("ModuleName was already existing");

            await _unitofwork.mainmenu.UpdateMainmenu(main);
            await _unitofwork.CompleteAsync();
            return Ok(main);
        }

        [HttpPut]
        [Route("UpdateActiveMainmenu")]
        public async Task<IActionResult> Updateactivemainmenu(MainMenu main)
        {
            var validateId = await _unitofwork.mainmenu.ValidatemainmenuId(main.Id);

            if (validateId == false)
                return BadRequest("Mainmenu Id is nut existing");
            if (await _unitofwork.mainmenu.ExistModuleName(main.ModuleName))
                return BadRequest("ModuleName was already existing");

            await _unitofwork.mainmenu.UpdateActiveMainmenu(main);
            await _unitofwork.CompleteAsync();
            return Ok(main);
        }

        [HttpPut]
        [Route("UpdateInActiveMainmenu")]
        public async Task<IActionResult> UpdateInactivemainmenu(MainMenu main)
        {
            var validateId = await _unitofwork.mainmenu.ValidatemainmenuId(main.Id);

            if (validateId == false)
                return BadRequest("Mainmenu Id is nut existing");
            if (await _unitofwork.mainmenu.ExistModuleName(main.ModuleName))
                return BadRequest("ModuleName was already existing");

            await _unitofwork.mainmenu.UpdateInActiveMainmenu(main);
            await _unitofwork.CompleteAsync();
            return Ok(main);
        }



    }
}
