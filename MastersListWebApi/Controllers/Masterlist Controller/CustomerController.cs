using ClassLibrary.Data_Acess_Layer.model.Masterlist;
using ClassLibrary.Interface.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MastersListWebApi.Controllers.Masterlist_Controller
{


    public class CustomerController : BaseApiController
    {
        private readonly IUnitofWork _unitofwork;

        public CustomerController(IUnitofWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpPost]
        [Route("AddnewCustomer")]

        public async Task<IActionResult> Addnewcustomer(Customer customer)
        {
            if (await _unitofwork.customer.ValidateCustomerCode(customer.CustomerCode))
                return BadRequest("CustomerCode Was already Existing, please Enter Another input");

            await _unitofwork.customer.AddNewCustomer(customer);
            await _unitofwork.CompleteAsync();
            return Ok(customer);
        }

        [HttpGet]
      [Route("GetAllACtiveCustomer")]
     public async Task<IActionResult> GetAllActiveCustomer()
        {
            var customer = await _unitofwork.customer.GetAllActiveCustomer();
            return Ok(customer);
        }


        [HttpGet]
        [Route("GetAllInACtiveCustomer")]
        public async Task<IActionResult> GetAllInActiveCustomer()
        {
            var customer = await _unitofwork.customer.GetAllInActiveCustomer();
            return Ok(customer);
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> GetAllUpdate(Customer customer)
        {
            var validatecustomer = await _unitofwork.customer.UpdateCustomer(customer);

            if(validatecustomer == false)
                return BadRequest("No Customer Id Exist");
            if (await _unitofwork.customer.ValidateCustomerCode(customer.CustomerCode))
                return BadRequest("Customer Code is already Exist, Please try another input ");

            await _unitofwork.customer.UpdateCustomer(customer);
            await _unitofwork.CompleteAsync();
            return Ok(customer);    
        }

        [HttpPut]
        [Route("UpdateActiveCustomer")]
        public async Task<IActionResult> GetAllActiveUpdate(Customer customer)
        {
            var validatecustomer = await _unitofwork.customer.UpdateActiveCustomer(customer);

            if (validatecustomer == false)
                return BadRequest("No Customer Id Exist");

            await _unitofwork.customer.UpdateActiveCustomer(customer);
            await _unitofwork.CompleteAsync();
            return Ok(customer);

        }

        [HttpPut]
        [Route("UpdateInActiveCustomer")]
        public async Task<IActionResult> GetAllInActiveUpdate(Customer customer)
        {
            var validatecustomer = await _unitofwork.customer.UpdateInActiveCustomer(customer);

            if (validatecustomer == false)
                return BadRequest("No Customer Id Exist");

            await _unitofwork.customer.UpdateInActiveCustomer(customer);
            await _unitofwork.CompleteAsync();
            return Ok(customer);

        }




    }
}
