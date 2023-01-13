using ClassLibrary.Data_Acess_Layer.Dto.MasterlistDto;
using ClassLibrary.Interface.Masterlist_Interface;
using ClassLibrary.model;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Repository.Masterlist_Repository
{
    public class VendorRespository : VendorInterface
    {
        private readonly StoreContext _context;

        public VendorRespository(StoreContext context)
        {
            _context = context;

        }

        public async Task<IReadOnlyList<DtoVendor>> GetAllActiveVendor()
        {
            var Vendor = _context.VendorNames.Where(x => x.IsActive == true)
                                             .Select(x => new DtoVendor
                                             {
                                                 Id = x.Id,
                                                 VendorCode= x.VendorCode,
                                                 VendorcodeName = x.VendorcodeName,
                                                 Addedby = x.Addedby,
                                                 DateAdded= x.DateAdded,
                                                 IsActive = x.IsActive


                                             });
            return await Vendor.ToListAsync();
        }

        public async Task<IReadOnlyList<DtoVendor>> GetAllInActiveVendor()
        {

            var Vendor = _context.VendorNames.Where(x => x.IsActive == false)
                                             .Select(x => new DtoVendor
                                             {
                                                 Id = x.Id,
                                                 VendorCode = x.VendorCode,
                                                 VendorcodeName = x.VendorcodeName,
                                                 Addedby = x.Addedby,
                                                 DateAdded = x.DateAdded,
                                                 IsActive = x.IsActive

                                             });
            return await Vendor.ToListAsync();
        }



        public async Task<bool> VendorAdd(VendorName vendor)
        {
            await _context.AddAsync(vendor);    
            return true;
        }

        public async Task<bool> UpdateVendor(VendorName vendor)
        {
            var updatevendor = await _context.VendorNames.Where(x => x.Id == vendor.Id)
                              .FirstOrDefaultAsync();

            if (updatevendor == null)
            {
                return false;
            }

            updatevendor.VendorCode = vendor.VendorCode;
            updatevendor.VendorcodeName = vendor.VendorcodeName;    
            updatevendor.Addedby = vendor.Addedby;  
            updatevendor.DateAdded = vendor.DateAdded;

            return true;
        }

        public async Task<bool> VendorActiveVendor(VendorName vendor)
        {
            var updatevendor = await _context.VendorNames.Where(x => x.Id == vendor.Id)
                            .FirstOrDefaultAsync();

            if (updatevendor == null)
            {
                return false;
            }

            updatevendor.IsActive = vendor.IsActive = true;

            return true;
        }

        public async Task<bool> VendorInActive(VendorName vendor)
        {
            var updatevendor = await _context.VendorNames.Where(x => x.Id == vendor.Id)
                .FirstOrDefaultAsync();

            if (updatevendor == null)
            {
                return false;
            }

            updatevendor.IsActive = vendor.IsActive = false;

            return true;

        }


        // Validation Vendor


        public async Task<bool> VendorCodeValidation(string vendorcode)
        {
            return await _context.VendorNames.AnyAsync(x=> x.VendorCode == vendorcode); 

        }

        public async Task<bool> VendorDescriptionValidation(string vendordescription)
        {
            return await _context.VendorNames.AnyAsync(x => x.VendorcodeName == vendordescription);
        }


    }
}
