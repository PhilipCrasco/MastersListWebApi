using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;


namespace ClassLibrary.Interface.Masterlist_Interface
{
    public interface VendorInterface
    {
        Task<IReadOnlyList<DtoVendor>> GetAllActiveVendor();
        Task<IReadOnlyList<DtoVendor>> GetAllInActiveVendor();
    }
}
