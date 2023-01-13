using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.Data_Acess_Layer.model.Masterlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface.Masterlist_Interface
{
    public interface CustomerInterface
    {
        Task<bool> AddNewCustomer(Customer customer);
        Task<IReadOnlyList<DtoCustomer>> GetAllActiveCustomer();
        Task<IReadOnlyList<DtoCustomer>> GetAllInActiveCustomer();

        Task<bool> UpdateCustomer (Customer customer);
        Task<bool> UpdateActiveCustomer (Customer customer);
        Task<bool> UpdateInActiveCustomer(Customer customer);

        




        // Validation

        Task<bool> ValidateCustomerCode(string customerName);
        
    }
}
