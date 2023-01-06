using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;

namespace ClassLibrary.Interface.Masterlist_Interface
{
    public interface UomInterface
    {
        Task<IReadOnlyList<DtoUom>> GetAllActiveUom();
        Task<IReadOnlyList<DtoUom>> GetAllInActiveUom();


    }
}
