using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.Data_Acess_Layer.model.Masterlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface.Masterlist_Interface
{
    public interface ItemCategoryInterface
    {
        Task<bool> AddnewItemCategory(ItemCategory itemCategory);
        Task<IReadOnlyList<DtoItemCategory>> GetAllActiveItemCategory();
        Task<IReadOnlyList<DtoItemCategory>> GetAllInActiveItemCategory();
        Task<bool> UpdateItemCategory(ItemCategory itemCategory);
        Task<bool> UpdateActiveItemCategory(ItemCategory itemCategory);
        Task<bool> UpdateInActiveItemCategory(ItemCategory itemCategory);


        // Validation

        Task<bool> ValidatedCategoryName(string CategoryName);
    }
}
