using ClassLibrary.Interface.IServices;
using ClassLibrary.model.PoSummary;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace MastersListWebApi.Controllers.Import_Controller
{
  
    public class PoSummaryController : BaseApiController
    {
        private readonly IUnitofWork _unitofwork;

        public PoSummaryController(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpPost]
        [Route("AddPoSummary")]
        public async Task<ActionResult> AddnewPosummary([FromBody ] PoSummary[]posummary ) // Array the output for PoSummary
        {
            if (ModelState.IsValid)
            {
           
                List<PoSummary> duplicateList = new List<PoSummary>();
                List<PoSummary> availableimport = new List<PoSummary>();
                List<PoSummary> vendornotexist = new List<PoSummary>();
                List<PoSummary> itemcodenotexist = new List<PoSummary>();
                List<PoSummary> uomodenotexist = new List<PoSummary>();

                

                foreach (PoSummary items in posummary)
                {

                    var validatevendor = await _unitofwork.poSummary.Checkvendor(items.Vendorname);
                    var validatePoAndItem = await _unitofwork.poSummary.ValidatePoandItemcodeManual(items.PoNumber, items.ItemCodes);
                
                    var validateItemcode = await _unitofwork.poSummary.CheckItemCode(items.ItemCodes);
                    var validationuom = await _unitofwork.poSummary.CheckUom(items.UOM);
                   
                   

               

                   if (validatePoAndItem == true)
                    {
                        duplicateList.Add(items);

                    }
                  else if(validatevendor == false)
                    {
                        vendornotexist.Add(items);
                    }
                  else if(validationuom == false)
                    {
                        uomodenotexist.Add(items);
                    }
                  else if (validateItemcode == false)
                    {
                        itemcodenotexist.Add(items);
                    }
                  else
                    {
                        availableimport.Add(items);
                        await _unitofwork.poSummary.AddPoSummaryRequest(items);
                    }


                }

                var resultlist = new
                {
                   
                    availableimport,
                    vendornotexist,
                    uomodenotexist,
                    itemcodenotexist,
                    duplicateList
                };

                if(duplicateList.Count==0 && vendornotexist.Count == 0 && itemcodenotexist.Count == 0 && uomodenotexist.Count==0 )
                {


                    await _unitofwork.CompleteAsync();
                    return Ok("Successfully Add!");
                }
                else
                {
                    return BadRequest(resultlist);
                }


            }

            return new JsonResult("something went Wrong!")
            {
                StatusCode = 500
            };

        }

    }
}
