using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.model.Masterlist;

namespace ClassLibrary.Interface.Masterlist_Interface
{
    public interface UomInterface
    {
        Task<IReadOnlyList<DtoUom>> GetAllActiveUom();
        Task<IReadOnlyList<DtoUom>> GetAllInActiveUom();

        Task<bool> AddUom(Uom uom);

        Task<bool> UpdateUom(Uom uom);
        Task<bool> UpdateActiveUom(Uom uom);
        Task<bool> UpdateInActiveUom(Uom uom);


        // Validation 

        Task<bool> ValidateUomDescription(string uomdiscription);
        Task<bool> ItemCodeExist(string itemcode);


    }
}
