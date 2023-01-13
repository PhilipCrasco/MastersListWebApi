using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.Data_Acess_Layer.model.Masterlist;
using ClassLibrary.Interface.Masterlist_Interface;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data_Acess_Layer.Repository
{
    public class CustomerRepository : CustomerInterface
    {

        private readonly StoreContext _context;

        public CustomerRepository(StoreContext context)
        {
          _context= context;
        }




        public async Task<bool> AddNewCustomer(Customer customer)
        {
             await _context.Customers.AddAsync(customer); 
            return true;

        }

        public async Task<IReadOnlyList<DtoCustomer>> GetAllActiveCustomer()
        {
            var customer =  _context.Customers.Where(x => x.IsActive == true)
                                                   .Select(x => new DtoCustomer
                                                   {
                                                       Id= x.Id,
                                                       CustomerCode= x.CustomerCode,
                                                       CustomerName= x.CustomerName,
                                                       MobileNumber= x.MobileNumber,
                                                       Address= x.Address,
                                                       DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                                       AdddedBy= x.AdddedBy,
                                                       IsActive= x.IsActive
                                                       



                                                   });

            return await customer.ToListAsync();


                                                    
        }

        public async Task<IReadOnlyList<DtoCustomer>> GetAllInActiveCustomer()
        {
            var customer = _context.Customers.Where(x => x.IsActive == false)
                                                  .Select(x => new DtoCustomer
                                                  {
                                                      Id = x.Id,
                                                      CustomerCode = x.CustomerCode,
                                                      CustomerName = x.CustomerName,
                                                      MobileNumber = x.MobileNumber,
                                                      Address = x.Address,
                                                      DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                                      AdddedBy = x.AdddedBy,
                                                      IsActive = x.IsActive




                                                  });

            return await customer.ToListAsync();
        }



        public  async Task<bool> UpdateCustomer(Customer customer)
        {
            var updateCustomer = await _context.Customers.Where(x => x.Id == customer.Id)
                                                         .FirstOrDefaultAsync();


            if (updateCustomer == null)
            {
                return false;
            }

            updateCustomer.CustomerCode = customer.CustomerCode;
            updateCustomer.CustomerName = customer.CustomerName;
            updateCustomer.Address = customer.Address;
            updateCustomer.DateAdded = customer.DateAdded;
            updateCustomer.AdddedBy = customer.AdddedBy;

            return true;
        }

        public async Task<bool> UpdateActiveCustomer(Customer customer)
        {
            var updateCustomer = await _context.Customers.Where(x => x.Id == customer.Id)
                                                         .FirstOrDefaultAsync();

            if(updateCustomer == null)
            {
                return false;
            }

            updateCustomer.IsActive = customer.IsActive = true;
            return true;
        }

        public async Task<bool> UpdateInActiveCustomer(Customer customer)
        {
            var updateCustomer = await _context.Customers.Where(x => x.Id == customer.Id)
                                                          .FirstOrDefaultAsync();

            if (updateCustomer == null)
            {
                return false;
            }

            updateCustomer.IsActive = customer.IsActive = true;
            return true;
        }

        //Validation 

        public async Task<bool> ValidateCustomerCode(string customerCode)
        {
           return await _context.Customers.AnyAsync(x => x.CustomerCode == customerCode);   
        }
    }
}
