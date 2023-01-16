using ClassLibrary.Data_Acess_Layer.Dto.ImportDto;
using ClassLibrary.Data_Acess_Layer.Dto.Recieving.WareHouserReceivingDto;
using ClassLibrary.Data_Acess_Layer.model.Receiving;
using ClassLibrary.Extensions;
using ClassLibrary.Helper;
using ClassLibrary.Interface.IServices;
using ClassLibrary.model.PoSummary;
using Microsoft.AspNetCore.Mvc;

namespace MastersListWebApi.Controllers.Receiving_Controller
{

    public class WarehouseReceivingController : BaseApiController
    {
        private readonly IUnitofWork _unitofwork;

        public WarehouseReceivingController(IUnitofWork unitofWork)
        {
            _unitofwork = unitofWork;
                
        }

        [HttpPost]
        [Route("AddNewReceivingInformationInPo")]
        public async Task<IActionResult> AddnewReciecivingInformationInpo(Warehouse_Receiving receiving)
        {
            await _unitofwork.wareHouseReceiving.AddNewReceivingDetais(receiving);

            return Ok(receiving);
        }

        [HttpPut]
        [Route(("EditRecievingDetails"))]
        public async Task<IActionResult> EditreceivingDetails (int id, [FromBody] Warehouse_Receiving receiving)
        {
            if (id == receiving.Po_SummaryID)
                return BadRequest();
            if (receiving.ActuallDelivered <= 0) 
                return BadRequest("Recieved failed, please check your input in actual delivered!");

            var  validatePoId = await _unitofwork.wareHouseReceiving.ValidatePoId(receiving.Po_SummaryID);
            if (validatePoId == false)
                return BadRequest("Update failed, PO does not exist!");
            var validateActualGood = await _unitofwork.wareHouseReceiving.ValidateActualRemaining(receiving);

            if (validateActualGood == false)
                return BadRequest("Receive failed, You're trying to input greater than the total received!");

            await _unitofwork.wareHouseReceiving.EditReceivingDetails(receiving);
                await _unitofwork.CompleteAsync();
            return Ok(receiving);

        }


        [HttpGet]
        [Route("GetAllAvailablePoWithPagination")]
        public async Task<ActionResult<IEnumerable<DtoPoSummary>>> GetAllPoSummarywithPagination([FromQuery] UserParameter userParams)
        {
            var posummary = await _unitofwork.wareHouseReceiving.GetAllPoSummaryWithPagination(userParams);
            Response.AddPaginationHeader(posummary.CurrentPage, posummary.PageSize, posummary.TotalCount, posummary.TotalPages, posummary.HasPreviousPage, posummary.HasNextPage);


                var posummaryResult = new
                {
                    posummary,
                    posummary.CurrentPage,
                    posummary.PageSize,
                    posummary.TotalCount,
                    posummary.TotalPages,
                    posummary.HasPreviousPage,
                    posummary.HasNextPage
                };


            return Ok(posummaryResult);

        }

        [HttpGet]
        [Route("GetAllAvailablePowithPaginationOrig")]
        public async Task<ActionResult<IEnumerable<DtoPoSummary>>> GetAllAvailableByWithPaginationOrig([FromQuery] UserParameter userParams , [FromQuery] string search)
        {
            if (search == null)
                return await GetAllPoSummarywithPagination(userParams);
            
            var posummary = await _unitofwork.wareHouseReceiving.GetPoSummaryByStatusWithPaginationOrig(userParams, search);
            Response.AddPaginationHeader(posummary.CurrentPage, posummary.PageSize, posummary.TotalCount, posummary.TotalPages, posummary.HasNextPage, posummary.HasPreviousPage);

            var posummaryResult = new
            {
                posummary,
                posummary.CurrentPage,
                posummary.PageSize,
                posummary.TotalCount,
                posummary.TotalPages,
                posummary.HasPreviousPage,
                posummary.HasNextPage
            };

            return Ok(posummaryResult);

        }

        [HttpPut]
        [Route("CancelPoSummary")]
        public async Task<IActionResult> CancelpoSummary([FromBody] PoSummary summary)
        {
            var validate = await _unitofwork.wareHouseReceiving.CancelPoSummary(summary);
            if (validate == false)
            {
                return BadRequest("Cancel Failed you have materials for receiving in warehouse");
            }

            await _unitofwork.wareHouseReceiving.CancelPoSummary(summary);
            await _unitofwork.CompleteAsync();
            return new JsonResult("Successfully Cancelled Po Summary!");

        }

        [HttpGet]
        [Route("GetAllCancelledPOWithPagination")]
        public async Task<ActionResult<IEnumerable<DtoCancelled>>> GetAllCancelledWithPagination([FromQuery] UserParameter UserParams)
        {
            var cancel = await _unitofwork.wareHouseReceiving.GetAllCancelledPoWithPagination(UserParams);
            
            Response.AddPaginationHeader(cancel.CurrentPage , cancel.PageSize , cancel.TotalCount , cancel.TotalPages ,cancel.HasNextPage , cancel.HasPreviousPage );

            var warehouseResult = new
            {
                cancel,
                cancel.CurrentPage,
                cancel.PageSize,
                cancel.TotalCount,
                cancel.TotalPages,
                cancel.HasNextPage,
                cancel.HasPreviousPage
            };
            return Ok (warehouseResult);
        }

        [HttpGet]
        [Route("GetAllCancelledPOWithPaginationOrig")]
        public async Task<ActionResult<IEnumerable<DtoCancelled>>> GetAllCancelledWithPaginationOrig([FromQuery] UserParameter UserParams, [FromQuery] string search)
        {
            if (search == null)
                return await GetAllCancelledWithPagination(UserParams);
            var cancel = await _unitofwork.wareHouseReceiving.GetAllCancelledPoWithPaginationOrig(UserParams, search);

            Response.AddPaginationHeader(cancel.CurrentPage, cancel.PageSize, cancel.TotalCount, cancel.TotalPages, cancel.HasNextPage, cancel.HasPreviousPage);

            var warehouseResult = new
            {
                cancel,
                cancel.CurrentPage,
                cancel.PageSize,
                cancel.TotalCount,
                cancel.TotalPages,
                cancel.HasNextPage,
                cancel.HasPreviousPage
            };
            return Ok(warehouseResult);
        }






    }
}
