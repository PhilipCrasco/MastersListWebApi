using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.model.Masterlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface.Inter_Core
{
    public interface ItemCodesInterface
    {
        Task<IReadOnlyList<DtoItemcodes>> GetAllActiveItem();
        Task<IReadOnlyList<DtoItemcodes>> GetAllInActiveItem();


        Task<bool> AddItem(ItemCode itemcode);

        Task<bool> UpdateItemCode(ItemCode itemcode);
        Task<bool> UpdateActiveItem(ItemCode itemcode);
        Task<bool> UpdateInActive(ItemCode itemcode);





        // Validation of Item

        
        Task<bool> ValidateUomId(int id);
        
        Task<bool> ValidateCodeExist(string itemcode);
        Task<bool> ValidateItemCategoryId(int Id);
    
        
        




    }
}
