using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.model;

namespace ClassLibrary.Interface.Masterlist_Interface
{
    public interface VendorInterface
    {
        Task<IReadOnlyList<DtoVendor>> GetAllActiveVendor();
        Task<IReadOnlyList<DtoVendor>> GetAllInActiveVendor();

        Task<bool> VendorAdd (VendorName vendor);


        Task <bool> UpdateVendor (VendorName vendor);
        Task<bool> VendorActiveVendor (VendorName vendor);
        Task<bool> VendorInActive (VendorName vendor);

        //Validation

        Task<bool> VendorCodeValidation(string vendorcode);
        Task<bool> VendorDescriptionValidation(string vendordescription);

    }
}
